Version 3.2.4
-------------
Changed: OwinHost and SelfHost does not depend on WebHost any more. 
This is a **Breaking Change**, Please install package "Ninject.Web.WebApi.WebHost" if use WebHost, but not just "Ninject.Web.WebApi".

Version 3.2.3
-------------
Added support for passing in HttpServer to UseNinjectWebApi

Version 3.2.2
-------------
Added Microsoft.Owin 3.0 support

Version 3.2.1
---------------
- Moved common bindings to Ninject.Web.Common so that multiple web extensions can be used together.
- Fixed that filters on the configuration are not executed twice

Version 3.2.0
-------------
Added Owin support

Version 3.0.0.0
---------------
initial version
