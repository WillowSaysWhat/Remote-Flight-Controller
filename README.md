![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/d7fa08e3-1908-4449-a266-e21991a563aa)

# Remote Flight Controller
#### A novice flight controller made for a computer science assessment.

## Table of Contents
* [Description of Software](#description-of-software)
* [Software Elements](#software-elements)
* [Understanding the User Interface](#understanding-the-user-interface)
* [Operating Panels](#operating-panels)
  
## Description of Software
The Remote Flight Controller is a simple interface that allows you to control a basic flight simulator via Internet Protocol (IP) connection. It is crafted for educational purposes and can be used as an example of event-driven and socket programming, demonstrating scalable techniques in beginner software development.
#### Key Features
*	**User-friendly** Interface: Navigate through the software effortlessly with a recognisable interface.
*	**Real-time Control:** Adjust flight parameters in real-time, including altitude, speed, and direction. 
*	**Open-Source:** Tailor the software or use features in your own software. Customise the Controller to suit your needs.
*	**Scalable:** The Remote Flight Controller is built so more features can be added without altering the source code.
*	**Built for Novices:** An easy project for C# programmers to delve in open-source contribution.
  
Whether you are a novice event-driven programmer or someone wanting to experience the Remote Flight Controller, this manual will guide you through the installation process, provide detailed instructions on using each feature, and help you make the most of your requirements of the Remote Flight Controller.

## Software Elements
The application has two distinct graphical user interfaces: the Remote Flight Controller and the original Flight Simulator. Developed using Unity and C#, the Flight Simulator provides a realistic and immersive virtual environment for flight experiences.
These Graphical User Interfaces communicate seamlessly through socket networking. This requires the specification of the localhost IP address and a port number – which is automatically provided by both Graphical User Interfaces. This enables the exchange of information between the Remote Flight Controller and the Flight Simulator.
For detailed instructions on connecting and operating the simulator with the controller, please refer to the "Operation/Use" section. To enhance your experience, consider placing the Flight Simulator and Remote Flight Controller side by side for a more immersive and enjoyable simulation.

![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/3d2f5dc8-4a37-4e86-82d0-c596be066885)

## understanding the User Interface

![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/cb8a634e-81d2-4cea-b9af-6389adecea4c)

|ALPHA	|NAME	             |FUNCTION                                                                                     |
|:----|:------------------|:--------------------------------------------------------------------------------------------| 
| A   |IP Address Input   | Visualises the localhost ip address and the port needed to connect to the Flight Simulator. |
|     |Port Input.        | The port is always pre-filled with the correct port.                                        |
| B	  |Dis/connect Buttons| Connects and disconnect controller from the Flight Simulator.                               |
| C	  |Close Button	      | Closes the Remote Flight Controller.                                                        |
| D	  |Telemetry Table    |	Displays telemetry from the Flight Simulator.                                               |
| E   |Warning Panel	     | Displays the warnings. No Warning, Stalled, Low Altitude.                                   |
| F	  |Controls Table	    | Displays any adjustments made to the controls.                                              |
| G   |Flight Controls	   | Controls the Throttle and Elevation speed of the Simulator.                                 |
| H	  |Telemetry Gauges	  | Visualises the Flight Simulator telemetry with guages.                                      |
| I	  |Telemetry Values	  | Displays telemetry value in numerical form.                                                 |

 
## Operating Panels
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/09895b4c-d80e-41c0-b362-99190a5216cf)
 
The image above illustrates the important panels on both graphical user interfaces, the Controller connection panel, the Flight Simulator connection panel, and the Control Panel.
While a chapter is dedicated to describing the step-by-step operation of the remote flight controller, a quick overview of the important operation panels will help to clarify and reenforce the steps necessary to successfully fly the plane.

To assist in simplifying the use of the remote flight controller, the above panels should be separated into two steps of operation: Connect, and Control.


 | Hint: 	Notice that the Flight Simulator has a Light theme, and the Remote Flight Controller     has a Dark theme.|
 |------------------------------------------------------------------------------------------------------------------|

### Connect
The first step of operation is to connect the Remote Flight Controller to the Flight Simulator. To do this we must first identify the Flight Simulator’s connection panel, which holds the ‘Open Port’ button – labelled ‘D’ in figure 3. This can also be verified in figure 1. This button tells the Flight Simulator to prepare for connection.
Next, the Operator will be asked to find and execute steps on the remote Flight Controller’s connection panel. This panel holds the ‘IP Address’ input field (A), and the ‘Port’ input field (B). The ‘Connect’ (C) and ‘Disconnect’ (D) buttons are located under the aforementioned, and the ‘Close’ (E) and ‘Help’ (F) buttons adjacent.
Recognising the connection panels will help in the coming Operation/Use chapter.

### Control
The second step of operation will only require the use of the Controls Panel, which consists of two controls: a throttle control and an elevation control. This allows the Operator to adjust the aircraft’s pitch and acceleration.
The Controls Panel is located to the centre-right of the Remote Flight Controller (figure 2).
Finally, to start the flight simulation, the Operator will need to locate the ‘Start Sim’ button. It can be found on figure 1 by using the following prompts:
1.	Locate the Flight Simulator GUI (Light theme).
2.	Locate the far-right gauge labelled ‘Vertical Speed’.
3.	Locate the scenario dropdown box below the gauge labelled ‘None Selected’.
4.	The ‘Start Sim’ button is directly below the dropdown box.
Prior knowledge of the control’s location will assist in minimising wait times during take-off.

 
