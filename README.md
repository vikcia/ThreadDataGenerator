# Multithreaded Data Generation WPF Application

## Overview
This application allows users to specify the quantity of threads for generating random data. Each thread autonomously produces random strings within a defined time interval. The latest 20 data entries are displayed in a ListView. Upon user stopping threads, the data is written to a (.mdb) file and all threads are cleared from the ListView. Built with C#, ADO.NET, and WPF.
## Running
- Run the application using the Visual Studio.
- Or run **ThreadDataGenerator.sln** solution inside ThreadDataGenerator folder.
- Application will launch WPF window.
  
![image](https://github.com/vikcia/ThreadDataGenerator/assets/104791026/1c367ed7-a456-40e5-ba66-e64bc52ee326)

## Usage
1. Specify the number of threads for data generation.
2. Start the process to generate random strings autonomously.
3. View the latest 20 data entries in the ListView.
4. Stop the threads to write data to a (.mdb) file and clear the ListView.

