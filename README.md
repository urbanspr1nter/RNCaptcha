RNCaptcha
==

CAPTCHA Image Generator in .NET/C#

Roger Ngo, <rogerngo90@gmail.com>

May 11, 2014

---

## Distribution

GPL License, I guess.

http://www.gnu.org/licenses/gpl.html

## Introduction
**RNCaptcha** generates a random string of alphanumeric characters (8) that is outputted to an image with artifacts to serve as a captcha. 

For the complete project write up please view:
http://rogerngo.com/Posts/View/20/creating-a-simple-captcha-in-net


Visual Studio 2012 was used to develop this project.

## Compiling the Project
Nothing special really needed to compile the project as it uses standard .NET Framework 4.5 libraries.

So, just press `CTRL+SHIFT+B` to build!

## Usage
I have provided a second project, `RNCaptcha.Test` to show basic usage on how to return an HTML IMG string to embed into a web page.

To create an RNCaptcha object just type:

`RNCaptcha cap = new RNCaptcha(RNCaptcha.GenerateRandomString());`

From here, you will want to invoke the `GetCaptcha()` method to generate the necessary markeup.

---

## API


### GenerateCaptcha.cs

* `RNCaptcha(string answer)` - This is the parameterized constructor to generate a captcha that will contain the specified "key".
* `RNCaptcha(int width, int height, int fontSize, string answer)` - Parameterized constructor for a more customized version of the captcha.
* `GenerateRandomString()` - Utility function. Generates a string containing  8 random alphanumeric characters.
* `GenerateMarkup()` - Generates an HTML img markup containing the base64 representation of the captcha output.
* `GetCaptcha()` - Generates the base64 representation of the captcha output.
---
END!