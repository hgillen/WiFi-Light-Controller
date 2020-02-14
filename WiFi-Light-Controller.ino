
/*
  WiFi UDP Send and Receive String

 This sketch wait an UDP packet on localPort using the WiFi module.
 When a packet is received an Acknowledge packet is sent to the client on port remotePort

 created 30 December 2012
 by dlf (Metodo2 srl)

 */


#include <SPI.h>
#include <WiFiNINA.h>
#include <WiFiUdp.h>

int status = WL_IDLE_STATUS;
#include "arduino_secrets.h" 
///////please enter your sensitive data in the Secret tab/arduino_secrets.h
char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;    // your network password  (use for WPA, or use as key for WEP)
int keyIndex = 0;            // your network key Index number (needed only for WEP)

unsigned int localPort = 11000;      // local port to listen on

char packetBuffer[255]; //buffer to hold incoming packet
char ReplyBuffer[] = "acknowledged";       // a string to send back

WiFiUDP Udp;

const int redOut = 1;
const int greenOut = 2;
const int blueOut = 3;
const int statusPin = LED_BUILTIN;
int ledState = LOW;

void setup() {
  pinMode(redOut, OUTPUT);
  pinMode(greenOut, OUTPUT);
  pinMode(blueOut, OUTPUT);

  analogWrite(redOut, 0);
  analogWrite(greenOut, 0);
  analogWrite(blueOut, 0);
  
  //Initialize serial and wait for port to open:
  Serial.begin(9600);
  //while (!Serial) {
    //; // wait for serial port to connect. Needed for native USB port only
  //}

  // check for the WiFi module:
  if (WiFi.status() == WL_NO_MODULE) {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true);
  }

  String fv = WiFi.firmwareVersion();
  if (fv < "1.0.0") {
    Serial.println("Please upgrade the firmware");
  }

  // attempt to connect to Wifi network:
  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
    status = WiFi.begin(ssid, pass);

    // wait 10 seconds for connection:
    //delay(10000);

    for (int i = 0; i < 10; ++i)
    {
        digitalWrite(statusPin, HIGH);
        delay(500);
        digitalWrite(statusPin, LOW);
        delay(500);
    }
    
  }
  Serial.println("Connected to wifi");
  printWifiStatus();
  digitalWrite(statusPin, HIGH);

  Serial.println("\nStarting connection to server...");
  // if you get a connection, report back via serial:
  Udp.begin(localPort);
}

void loop()
{

  // if there's data available, read a packet
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    Serial.print("Received packet of size ");
    Serial.println(packetSize);
    Serial.print("From ");
    IPAddress remoteIp = Udp.remoteIP();
    Serial.print(remoteIp);
    Serial.print(", on port ");
    Serial.println(Udp.remotePort());

    // read the packet into packetBuffer
    int len = Udp.read(packetBuffer, 255);
    if (len > 0) {
      packetBuffer[len] = 0;
    }
    Serial.println("Contents:");
    
    Serial.print(convertInt((int)packetBuffer[0]));
    Serial.print(", ");
    Serial.print(convertInt((int)packetBuffer[1]));
    Serial.print(", ");
    Serial.println(convertInt((int)packetBuffer[2]));
    Serial.print(", ");
    Serial.println(convertInt((int)packetBuffer[3]));

    if (strcmp(packetBuffer, "MARK") == 0)
    {
        Serial.println("MARK recvd, sending SYNC");
        Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
        Udp.write("SYNC");//ReplyBuffer);
        Udp.endPacket();
        digitalWrite(statusPin, LOW);
    }

    
    if (packetBuffer[0] > 0 && packetBuffer[0] <= 255)
    {
      Serial.println("Sending Red High command");
      analogWrite(redOut, packetBuffer[0]);
      //delay(1000);
      //ledState = LOW;
    }
    else
    {
      analogWrite(redOut, 0);      
    }

    if (packetBuffer[1] > 0 && packetBuffer[1] <= 255)
    {
      Serial.println("Sending Green High command");
      analogWrite(greenOut, packetBuffer[1]);
    }
    else
    {
      analogWrite(greenOut, 0);      
    }

    if (packetBuffer[2] > 0 && packetBuffer[2] <= 255)
    {
      Serial.println("Sending Blue High command");
      analogWrite(blueOut, packetBuffer[2]);
    }
    else
    {
      analogWrite(blueOut, 0);      
    }
    //digitalWrite(1, ledState);

    // send a reply, to the IP address and port that sent us the packet we received
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    Udp.write(packetBuffer);//ReplyBuffer);
    Udp.endPacket();
  }
}


void printWifiStatus() {
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your WiFi shield's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println(" dBm");
}


char *convertInt(int in)
{
  char ret[4] = "   ";
  if (in < 10)
  {
    ret[2] = (char)(in + '0');
    return ret;
  }
  else if (in < 100)
  {
    ret[1] = (char)((in / 10) + '0');
    ret[2] = (char)((in % 10) + '0');
    return ret;
  }
  else
  {
    ret[0] = (char)((in / 100) + '0');
    ret[1] = (char)(((in % 100) / 10) + '0');
    ret[2] = (char)((in % 10) + '0');
    return ret;
  }
}



