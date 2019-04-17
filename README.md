# Fitness Companion Application

An application that helps user keep track of their nutrition values throughout
the day.

## Getting Started

Clone this git repo to download the program's solution file.

### Prerequisites

```
- Visual Studio 2017 (Xamarin Forms, Newtonsoft.Json Dependency)
- Android device with at least version 5.0 (Lollipop)
- Any Window device
```

### Installing

- Go to the downloaded folder and go into the main folder.
- In each folder delete the "bin" and "obj" folder.
- Open the "sln" file using Visual Studio.
- Build the solution to ensure no errors.

For Window device
```
- Run the UWP version from Visual Studio.
- It will build and install onto the computer.
```

For Android device
```
- Enable USB debugging on the device.
- Connect device to computer using USB.
- Run Android version from Visual Studio.
- It will build and install onto the Android device.
```

## Usage

The app is fairly simple to use.

### Pages
Login Page
```
- Simple login page with username and password input.
- Register button to register if no account available.
- Login with an account.
- Default account are username: "admin" password: "admin".
```

Tracker Page
```
- Track user nutrition values.
- Click "Add Intake" button in any meal (Breakfast/Lunch etc.).
- Add all details about an intake.
- The intake was added to the Tracker with calculated totals.
- Also shown daily totals/ user goals and remaining values.
```

BMI Page
```
- Calculate BMI from weight and height.
- Default value is user account's weight and height.
- Input and press "Calculate" button to get result.
```

Account Page
```
- A page where user can change account parameters.
- Height/Weight/Goals are Bind with INotifyPropertyChanged.
```

About Page
```
- Just a simple page describing the application.
```
## Warning

There are still [issues](https://github.com/BernardWong97/Fitness-Companion/issues) on the application.

## Researches

These are the references/researches to help build the program:
- [Simplifying MVVM INotifyPropertyChanged On Xamarin.Forms](https://www.c-sharpcorner.com/article/simplifying-mvvm-inotifypropertychanged-on-xamarin-forms/)
- [Page.OnAppearing Method](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.page.onappearing?view=xamarin-forms)
- [Configure App Icons in Xamarin Forms App](https://www.codeproject.com/Articles/1106631/Configure-App-Icons-in-Xamarin-Forms-App)
- [Xamarin.Forms Entry](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/entry)
- [Xamarin.Forms Tabbed Page](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/tabbed-page)
- [Xamarin.Forms ScrollView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/scroll-view)
- [KeyValuePair](https://www.dotnetperls.com/keyvaluepair)
- [C# - Dictionary<TKey, TValue>](https://www.tutorialsteacher.com/csharp/csharp-dictionary)
- [How to change application icon in Xamarin.Forms?](https://stackoverflow.com/questions/37945767/how-to-change-application-icon-in-xamarin-forms)

## Author

* **Bernard Wong** (https://github.com/BernardWong97)
