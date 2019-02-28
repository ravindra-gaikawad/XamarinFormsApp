# XamarinFormsApp
This sample provides you boilerplate or starter solution to develop Xamarin forms cross-platform application.
This project contains boilerplate for following components

- Platforms
  - Android
  - iOS
  - UWP
- Components
  - UnitTest
  - Local Database
  - Http Service Calls
  - Internal Service Calls   
- Investigation
  - The reference links and data is logged into file *XamarinForms Investigation.xlsx*. These file is placed at root level in solution.

## Features
  - XamarinForms MVVM architecture followed.
  - Dependecy Injection ready using Autofac.
  - UnitTest setup provided.
  - Decoupled architecture.
  
## Tools and Libraries Used
  - Visual Studio 2017.
  - Sqlite-Net-PCL.
  - XUnit and Moq.
  - Autofac.
  - Git

## Solution Structure
Solution structure is build such that inside projects would be loose coupled and can be reused independently as much as possible.
### Description
- Components
	- **XamarinFormsApp.Core**
  
		This is independent project.It contains elements which are referred by all other projects. Elements from this project do not contains any business logic.
		e.g. Models, Constants, Configurations, Enums
	- **XamarinFormsApp.Repository**
  
		This project contains sqlite repository service and its implementation. 
		Service is put in Definitions folder and Implementation is put in Implementations folder.
	- **XamarinFormsApp.Services**
  
		This project contains solution-wide required services and there implementations. 
		Services are put in Definitions folder and Implementations are put in Implementations folder.
		One special service is already added as HttpService, to make http calls generically.
	- **XamarinFormsApp.Utilities**
  
		This project contains all elements which act as utility provider in solution.
		e.g. Extension methods, Converters and other defined Helpers.
- Platforms
	- **XamarinFormsApp.Android**
  
	- **XamarinFormsApp.iOS**
  
	- **XamarinFormsApp.UWP**
- UnitTest
	- **[ProjectName].UnitTests**
  
		One sample unit test project added to test services.
		One class is written for method which is being tested.
		One method is written as to test, single test case.
- **XamarinFormsApp**

	.NetStandard Shared app.
	If possible do not use Models and Services folder from this project.
	However services folder can contain Definitions/Interfaces to be implemented in Platform specific apps.

## Not In Sample

Following things are not provided in solution, but you can implement as per you choice.
- Exception handling.
- Exception logging and crash reporting.
- UI tests
- Code Styling
