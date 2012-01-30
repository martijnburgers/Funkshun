Funkshun
========

A small and simple library which provides a simple implementation of a request-response pattern surrounded by helper classes for dealing with 
responses, functional messages and technical exceptions. This is done by defining a convention for returning method calls. This behaviour can 
be enforced by a special breed of methods called funkshuns or special return types. Read more if I got your attention.

Goals
-----

In every project the question should arise: how are we going to deal with functional errors, warnings and thrown exceptions? For this, your 
project should have a convention which must apply for all writen sofware. A solution could be to throw exceptions for functional errors, 
provide output parameters or even worse return a string with the error message. Now for all this kind of, let's be honest, simple problems 
Funkshun provides a more simple solution.

The Funkshun project believes in the following assumptions:

1. Only technical errors should be thrown by exceptions.
2. Functional messages can be part of the result of a method (even void methods) but are not mandatory. 
3. Functional messages have a severity (error, warning or information). 

With this in mind the goals of this project are:

1. Provide a simple convention for handling functional and technical messages/exceptions between method calls.
2. Provide helper methods which utilizes this convention and makes working with it easy en fun.

It doesn't fit in every situation but maybe perfectly in yours. Also checkout the other links for more information.

Download
--------
The project is available on:

* [GitHub](https://github.com/martijnburgers/Funkshun/)
* [Nuget](http://www.nuget.org/List/Packages/Funkshun.Core)

Other links
-------
* [Introduction to Funkshun](http://www.martijnburgers.net/post/2012/01/30/Introduction-to-Funkshun.aspx)
* [API Docs](http://www.martijnburgers.net/projects/funkshun/apidocs/)

Author
-------

[Martijn Burgers](http://www.martijnburgers.net) 
[@martijnburgers](http://twitter.com/martijnburgers)

License
-------

Released under the Apache License, Version 2.0. See the [LICENSE][license] file for further details.

[license]: https://github.com/martijnburgers/Funkshun/blob/master/Funkshun/LICENSE.md
