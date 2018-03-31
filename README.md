# MvvmLight_Frame_DesignTime
## Purpose
The purpose is to create an example program that shows how to populate a Frame with a Page during DESIGN TIME and uses the Frame Source property with a URI property during RUN TIME.  

The program starts with a MVVMLight WPF template generated with VS2017 and adds a frame, page + viewmodel, uri property, page design time data, and appropriate properties for binding. 

A stackoverflow question was asked about it here [StackOverflow 49247892](https://stackoverflow.com/questions/49247892/mvvmlight-display-page-in-frame-during-design-time) and this readme and stackoverflow contain the same information.  

This example code will be used in a larger MvvmLight template that has been created here called [MvvmLight_WPF_Frame_Nav](https://github.com/floppydisk525/MvvmLight_WPF_Frame_Nav).  The MvvmLight_WPF_Frame_Nav example program includes a navigation service and means to pass objects between viewmodels.  As of April 2018 that program is still a work in progress.  

## Goals
1. Use MVVMLight
2. Use a Frame Control, Frame.Source property, URI Property for the source to allow Navigation to work.
3. Enjoy the design time experience WPF & blend provide by having a FRAME populate a page during DESIGN TIME
4. Use SimpleIOC

## Releases
0.1.0. The 'Starter' applicaiton that DOES NOT work as desired.  This initial release does NOT show a PAGE in the FRAME at design time.  It does show the frame correctly at run time and can be used to prototype new ideas with a new branch. Left image is DESIGN TIME and Right image is RUN TIME.

![alt text][DesignTimeNoPageImage]![alt text][RunTimeWork]

0.1.1  This release shows a possible solution by using designtime ignore d: in the MainWindow.xaml along with using BOTH the Source and Content properties.  This solution leads to a Question - see issues below...  One thing to point out about this solution is that no datatemplates were added to App.xaml or the MainView.xaml files.  Also, no other objects (frame, page or other) are instantiated in the viewmodel or code behind.  

![alt text][DesignTimePageImageWorksNAVButtons]![alt text][RunTimeWork]

## Issues
Issue #1:  Is it ok to use the Source & Content property for the Frame?  Could this be done differently?  This is the 'secret sauce' code added to make the solution work:
```xml
<Frame HorizontalAlignment="Left" Height="237" Margin="25,120,0,0" VerticalAlignment="Top" Width="243"
               d:DataContext="{d:DesignInstance Type=v:IntroPage, IsDesignTimeCreatable=True}" 
               Content ="{Binding}"                 
               Source="{Binding FrameUri}"/>
```
To allow the the above code to work, the following lines were first added in the MainWindow.xaml file.
```xml
xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
xmlns:ignore="http://www.galasoft.ch/ignore"
xmlns:v="clr-namespace:MvvmLight_Frame_DesignTime"
```
```xml
d:DataContext="{d:DesignInstance Type=v:IntroPage, IsDesignTimeCreatable=True}" 
Content ="{Binding}"
```
The line Source = "{Binding FrameUri}" was removed.  The end result was DesignTime WORKED (Yay - Left Image).  However, RUN TIME did NOT work (Booo - Right Image).

![alt text][DesignTimePageImageWORKS]![alt text][RunTimeDoesNOTWorkTRIAL]

To achieve a workable solution, the Source="{Binding FrameUri}" was added back to the solution.  When the Source="{Binding FrameUri}" was added, the navigation bar showed up - strange.  Is there a better way to do this?

![alt text][DesignTimePageImageWorksNAVButtons]

NOTE:  After compiling and running the solution, the navigation buttons in the above image disappeared in design time.  Clearly, don't understand the internals.  The property to show the nav buttons could be set to true if we want them.  

Issue #2:  Post the MvvmLight toolkit version, etc.  
Issue #3:  Understanding of WPF/xaml.  Areas that could use better understanding include WPF/Xaml instantiation of objects & controls and diagnosing Xaml issues.  

## Comment
I wish you could set the Content property w/ a d:Content to tell the xaml parser/blend to only use Content at design time.  That would aleviate the program from looking at the Content and Source property at run time - however that works.  

[DesignTimeNoPageImage]: MvvmLight_Frame_DesignTime/github_Images/DesignTimeNoPageImage.PNG
[RunTimeWork]: MvvmLight_Frame_DesignTime/github_Images/RunTimeWork.PNG
[DesignTimePageImageWORKS]: MvvmLight_Frame_DesignTime/github_Images/DesignTimePageImageWORKS.PNG
[RunTimeDoesNOTWorkTRIAL]: MvvmLight_Frame_DesignTime/github_Images/RunTimeDoesNOTWorkTRIAL.PNG
[DesignTimePageImageWorksNAVButtons]: MvvmLight_Frame_DesignTime/github_Images/DesignTimePageImageWorksNAVButtons.PNG