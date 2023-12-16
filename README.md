![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/d7fa08e3-1908-4449-a266-e21991a563aa)

# Remote Flight Controller
#### A novice flight controller made for a computer science assessment.

## Table of Contents
* [Description of Software](#description-of-software)
    * [Key Features](key-features)
* [Software Elements](#software-elements)
* [Understanding the User Interface](#understanding-the-user-interface)
* [Operating Panels](#operating-panels)
    * [Connect](#connect)
    * [Control](#control)
* [Software Documentation](#software-documentation)
  * [Setting up the Environment](#setting-up-the-environment)
  * [The Code](#the-code)
      * [Adding Components to the Software](#adding-components-to-the-software)
  * [Writing the Code](#writing-the-code)
    * [Threads](#threads)
    * [Delegates and Events](#delegates-and-events)
  * [Maintenance and Improvements](#maintenance-and-improvements)
    * [How to Maintain the Software](#how-to-maintain-the-software)
    * [Future Improvements](#future-improvements)
    
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

## Understanding the User Interface

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

## Operation and Use 
The Remote Flight Controller is a learning tool for novice C# programmers; therefore, no traditional installation method has not been created. All software files are available for use. This means that a level of competency is needed to setup and run the Controller. The operator will need to check whether the NuGet package is installed. The instructions for this can be found in Software Documentation. 


#### Operational Environment
The remote Flight Controller was built using Visual Studio and it is recommended that operators and programmers use Visual Studio when running the program. To simplify the coming instructions, open the folder that holds the Remote Flight Controller
**open visual Studio**
1.	Right-click on RemoteFlightController.csproj (figure 4).
2.	Click on **Open**.
3.	Right-click on **Form1.cs** in the Solution Explorer.
4.	Select **View Design** (figure 5).
5.	Developers can view the code by repeating step 3 and selecting **View Code instead**.
   
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/8bbfd00a-3d49-4e03-9271-cfa4ca3c9ac2)

Successful completion of these steps should have the Remote Flight Controller project open and visible on the operators screen as demonstrated in figure 5.
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/eb2ded77-815a-4299-88ed-1365df1a7642)
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/0776043d-50c1-4967-86ce-277000cd8a08)

If the code shows any error messages, then a package installation may need to be performed. These packages are called NuGet Packages. The installation instructions are found in “Setting Up the Environment”.

#### Starting/Stopping the Application’s Operation
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/54fc815f-2112-452e-bfa2-3d77115c91a2)
**Start the Remote Flight Controller:**
1.	Click on the green “Play” button on Visual Studio’s menu bar.
2.	Click the “Open Port” Button on the Flight Simulator ( E ).
3.	Click the “Connect” button on the Remote Flight Controller ( C ).
4.	Confirm Connection by closing the pop-up message box.
5.	Click the “Start Sim” button on the Flight Simulator.
6.	Use the “Help” Button for simple instructions.

**Take off.**
To take-off, adjust the Throttle and Elevator Pitch to full and wait for the aircraft to climb before levelling off. There is a dropdown menu that allows you to select an event. The description will remain vague so that the operator can test each event for themselves.

**Stop the Remote Flight Controller:**
1.	Click the “Disconnect” button to stop receiving telemetry.
2.	To close the Remote Flight Controller, either press the “x” in the top right corner or click the close button.
3.	The Flight Simulator could close automatically upon disconnecting, however, the “x” in the top-right is also available to exit the program.

## Software Documentation
#### Setting up the Environment
To run the Remote Flight Controller. Visual Studio will need to be installed. Instructions for the installation of Visual Studio can be found [here](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022).

Further installations may need to be completed for the Remote Flight Controller to work. For example, the Live Chart package should be present in the project, however, installation may be required. 
Follow these steps to install the Live Charts NuGet package.

1.	To find your package manager window, right click on the name of your solution in the solution explorer. You can see in the image below that I have highlighted the correct selection. 
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/30623291-f093-4cb3-826e-f07cb82dbd49)

2.  The package manager screen will open in the "Installed" tab.
3.	You will need to change it to the "Browse" tab and search for 'LiveCharts'. The search bar is under the "Browse" tab.

 ![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/bbd0afab-5621-4786-bed7-c44a48b968ba)

4.	Ensure you are installing the correct version of LiveCharts for your the project. The Remote Flight Controller uses LiveCharts.Winfroms.
5.	The "Install" button is located on the right side of the packages window.
6.	This single selection will download all the dependencies.
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/1f71fe7c-ca2f-4661-a4f8-16e0c39a23c7)

7.	Ignore this webpage. just close it
![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/36b97729-a978-49e6-9ac9-337039f3d6a2)

The Live Charts NuGet package is now installed. This should solve any errors associated with the Angular Gauges on the Remote Flight Controller.
   
### The Code
#### Adding Components to the Software
The Remote Flight Controller is completely open source therefore, improvements and new features are encouraged. However, implementation will need to follow Event-Driven programming paradigms. Here is a list of examples where programming rules may need to be adhered to:
1.	Creating a loop to continuously monitor data will need to be executed via a Thread. For example, The Telemetry Object is created and populated via a while loop. If this was executed on the main thread, it would freeze the 
    GUI. To prevent this, the program creates a new thread so that it can loop concurrently while the main thread continues to serve the user and any buttons and trackbars they may interact with.
2.	Any new feature that requires the manipulation of the Angular Gauges, gauge labels, or data tables will need to be executed via a delegate and an event. Delegates and Events will be explained in the sub-chapter “Writing   
    the Code”.
3.	Both classes are structured to send and receive data from the Flight Simulator. These are not to be modified. The Flight Simulator will not receive new information. New objects can only be used within the Remote Flight 
    Controller.
New visual features added to the Graphical User Interface are welcomed. Therea are no restrictions on the positioning of new buttons and labels. The repositioning and optimisation of the current Graphical User Interface 
    feature is open to interpretation and any improvements will be committed to the main repository. 

### Writing the Code
#### Threads
Threads are an important part of graphical user interface design and event-driven programming. Without the option to create multiple threads, a GUI would suffer continuous inactivity. This would appear as if the graphical user interface has frozen. Threads are used to prevent this. 

The while loop in the Remote Flight Controller is a good example of this situation. Without the ability to create a thread to run the continuous loop, the while GUI would freeze. With two concurrent threads executing separate task without interfering with the other, the program can use one thread for GUI interaction and the other for receiving data from the Flight Simulator.
Thread creation is simple.  The program will need System.Threading to create threads. 

```using System.Threading;```

Initialise the thread.

''' Private Thread listenThread;```

The thread execution can be thought of as a function call. It will start a new threat that runs a function, but will not wait for, or interfere with any other processes already running. once the thread has a value, thisThread.Start() will execute the thread.

```listenThread = new Thread(new ThreadStart(ReceiveData));```

```listenThread.Start();```

The thread will then run the function, in this case, named ReveiveData.

#### Delegates and Events
A Delegate can be thought of as a contract or agreement that specifies what kind of task needs to be done. For example, a program may need to do a range of math with two integers.

```delegate int DoMathWithTwoInts(int a, int b);```

Interestingly, you can see that this delegate above does not agree to do addition, subtraction, or multiplication. It agrees to do math. This means that any function we create that requests a and b as an argument can be used with this delegate. But first we need to create the functions.
```
void addIntegers(int a, int b)
 {
     Console.WriteLine(a + b);
 }
 void minusIntegers(int a, int b)
 {
     Console.WriteLine(a - b);
 }
 void multiplyIntegers(int a, int b)
 {
     Console.WriteLine(a * b);
 }
```
These functions all execute different tasks but use the same arguments. This allows a single delegate to execute all three functions and allows for further events to be created using the delegate. Maybe a future feature will divide both integers.
Next, subscribe all three functions to the Event. The subscription is best placed within the constructor.

```
event DoMathWithTwoInts addthis += new DoMathWithTwoInts(addIntegers);
event DoMathWithTwoInts minusThis += new DoMathWithTwoInts(minusIntegers);
event DoMathWithTwoInts multiplyThis += new DoMathWithTwoInts(multiplyIntegers);
```
If there was no need to execute these sums individually. A single event could be initialised, and all delegates added to it. This would execute and print all results simultaneously. See below.
```
void invokeThis()
{
   addthis?.Invoke(1,2);
   minusThis?.Invoke(1,2);
   multiplyThis?.Invoke(1,2);
}
```
## Maintenance and Improvements

### How to maintain the Software
The Remote Flight Controller is a simple application for novice programming; therefore, no maintenance is necessary. However, Visual Studio will require periodic updates. These notifications are found in the bottom-right corner of the editor. Updates are visualised by a bell icon with a red notification alert.

![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/b60d2b4e-ff36-46b1-ba91-39433cadd806)

Figure 12: Visual Studio update notification
The Live Charts NuGet package will also need to be monitored for any patches. The “Updates” tab is found to the right od the “Installed” tab. Updates are highlighted on the tab by a blue rectangle-shaped notification icon. Instructions to find the NuGet Package management window can be found in Software Documentation chapter.

![image](https://github.com/WillowSaysWhat/Remote-Flight-Controller/assets/126318401/c28fc8c5-a7c0-4dc1-af86-3ec6870027ed)
#### Future Improvements

There are two major features that are to be added soon.
1.	Blackbox recorder
2.	Autopilot.
3.	
**Blackbox Recorder**
The Blackbox will record the telemetry data to a CSV file that will be in the “bin” folder of this project. Each entry will have the date, time, and each item of telemetry data.  The Blackbox feature will not overwrite data history but append only.
Update: the Blackbox has been implemented.

**Autopilot**
The button for the Autopilot is already visible on the Controller, however it is disabled until the autopilot can be fixed. It is currently crashing the aircraft. This will be improved in the coming updates.

