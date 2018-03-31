# MvvmLight_Frame_DesignTime
## Purpose
The purpose is to create an example program that shows how to populate a Frame with a Page during DESIGN TIME and uses the Frame Source property with a URI property during RUN TIME.  

The program starts with a MVVMLight WPF template generated with VS2017 and adds a frame, page + viewmodel, uri property, page design time data, and appropriate properties for binding. 

A stackoverflow question was asked about it here [StackOverflow 49247892](https://stackoverflow.com/questions/49247892/mvvmlight-display-page-in-frame-during-design-time)

This example code will be used in larger MvvmLight template that I've created a github repository [here called MvvmLight_WPF_Frame_Nav](https://github.com/floppydisk525/MvvmLight_WPF_Frame_Nav).  The MvvmLight_WPF_Frame_Nav example program includes a navigation service and means to pass objects between viewmodels.  As of April 2018 that program is still a work in progress.  

## Goals
1. Use MVVMLight
2. Use a Frame Control, Source property, URI Property
3. Enjoy the design time experience WPF & blend provide by having a FRAME populate a page during DESIGN TIME
4. Use SimpleIOC

## Releases
0.1.0. The 'Starter' applicaiton that DOES NOT work.  This version does NOT show a PAGE in the FRAME at design time.  It does show the frame correctly at run time. Left image is DESIGN TIME and Right image is RUN TIME.

![alt text][DesignTimeNoPageImage]![alt text][RunTimeWork]

0.1.1  This release shows a possible solution by using designtime ignore d: in the MainWindow.xaml along with using BOTH the Source and Content properties.  This solution leads to a Question - see issues below...  One thing to point out about this solution is that no datatemplates were added to App.xaml or the MainView.xaml files.  Also, no other objects (frame, page or other) are instantiated in the viewmodel or code behind.  

Design time Image                          Run Time Image
![alt text][DesignTimePageImageWorksNAVButtons]![alt text][RunTimeWork]

## Issues
Issue #1:  Is it ok to use the Source & Content property for the Frame?  Could this be done differently.
```xml
<Frame HorizontalAlignment="Left" Height="237" Margin="25,120,0,0" VerticalAlignment="Top" Width="243"
               d:DataContext="{d:DesignInstance Type=v:IntroPage, IsDesignTimeCreatable=True}" 
               Content ="{Binding}"                 
               Source="{Binding FrameUri}"/>
```
To get to the above code, the following lines were first tried.
```xml
xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
xmlns:ignore="http://www.galasoft.ch/ignore"
xmlns:v="clr-namespace:MvvmLight_Frame_DesignTime"
```
```xml
d:DataContext="{d:DesignInstance Type=v:IntroPage, IsDesignTimeCreatable=True}" 
Content ="{Binding}"
```
The line Source = "{Binding FrameUri}" was removed.  The end result was DesignTime WORKED (Yay - Left Image).  However, RUN TIME did NOT work (Right Image).

![alt text][DesignTimePageImageWORKS]![alt text][RunTimeDoesNOTWorkTRIAL]

Therefore, to achieve a workable solution, the Source="{Binding FrameUri}" was added and the solution works.  But is there a better way?  Note - when the Source="{Binding FrameUri}" was added, the navigation bar showed up - strange - something going here...

![alt text][DesignTimePageImageWorksNAVButtons]

Issue #2:  Post the MvvmLight toolkit version, etc.  
Issue #3:  Understanding of WPF/xaml.  Areas that could use better understanding include WPF/Xaml instantiation of objects & controls and diagnosing Xaml issues.  

## Comment
I wish you could set the Content property w/ a d:Content to tell the xaml parser/blend to only use Content at design time.  That would aleviate the program from looking at the Content and Source property at run time - however that works.  

[DesignTimeNoPageImage]: MvvmLight_Frame_DesignTime/github_Images/DesignTimeNoPageImage.PNG
[RunTimeWork]: MvvmLight_Frame_DesignTime/github_Images/RunTimeWork.PNG
[DesignTimePageImageWORKS]: MvvmLight_Frame_DesignTime/github_Images/DesignTimePageImageWORKS.PNG
[RunTimeDoesNOTWorkTRIAL]: MvvmLight_Frame_DesignTime/github_Images/RunTimeDoesNOTWorkTRIAL.PNG
[DesignTimePageImageWorksNAVButtons]: MvvmLight_Frame_DesignTime/github_Images/DesignTimePageImageWorksNAVButtons.PNG