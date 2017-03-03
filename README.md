## Portfolio

#### A site to display some of my work.

#### By **Anne Belka**


## Description
This project was generated in VisualStudio utilizing the github API to sort my repositories by the most starred. It will only display the top three. 

## Setup/Installation Requirements

Clone this repository: https://github.com/albelka/Portfolio-.Net
 and open it in Visual Studio.

 Go to https://github.com/settings/applications
and register an application to get your:
Client ID #
Client Secret #

In VisualStuio Solution Explorer
Create a class file in the Models folder and name it 'EnvironmentVariables.cs'

add:
	public class EnvironmentVariables
    {
        public static string ClientId = "{{your Client ID #}}";
        public static string ClientSecret = "{{your Client Secret #}}";
    }

Now you can run Portfolio in any modern browser.

## Technologies Used
* C#
* VisualStudio
* ASP.Net
* Github API

GPL

Copyright (c) 2017 **_Anne Belka_**