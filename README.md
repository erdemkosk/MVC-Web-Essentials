# WebSimplifier
A lightweight and easy-to-use web library for ASP .NET. It contains commonly used methods(like mail,time,password generator, etc..) for the website.


Instructions
============
When I developed my personal blog and resume web site, I realize that, always repeat myself for convert server time to local time or sending e-mail. In spite of getting bored, I decided to develop a library so that every developer can use it.

SlugHelper
==========
It generate Url slug for routing process.

string generatedLink = UrlSlugManager.GenerateSlug("test slug string example");,,
