# Xamarin.Forms Starter using .NetStandard 2.0
## See UWP Note


## Using:
* .NetStandard 2.0
* Xamarin Forms 3.4.0.1009999
* Unity (for IoC )

## Pages:
* Login Page
* Home screen is a MasterDetailPage
* Settings Page
* Logout Page
* Help Page that allows you to send an email

## Features:
* ffimageloading
* Toasts
* Doing as much as possible in this app to eliminate 3rd party plugins, so I'm using DependencyServices instead

## Works Using:
* Android
* iOS
* UWP

## Important Note for UWP (only need to do this once when you create a new project)
* open the App.xaml.cs file
* look for the line `// System.Guid desiredGuid = System.Guid.NewGuid();` and uncomment it
* put a break point after this line
* run the app and at the break point grab the new guid
* close the app and open the Package.appxmanifest file and edit the packaging: Package Name and replace the guid with this new guid you copied.
* re-comment the line

