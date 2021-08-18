# LiveNationWebAPI
**How to build the code**

The easiest way to build to code is to **open the solution in Visual Studio**. For this project I used Visual Studio 2019, Community Version.
Once the solution is open, it can be built by click on **Debug > Build Solution** or its shortcut **Ctrl + Alt + B**.

**How to run the output**

The application runs by pressing the **play button** at the upper-middle side in Visual Studio, or by pressing **F5**.
At this point, the user may use **Swagger UI** or a tool like Postman to send the requests. A Postman collection of requests has been added to the repository with some request examples.

**Requests:**
      - GetRangeResponse. **Two input values**: start (string) and end (string). **One output**: a json-formatted string.
      
      - SaveRule. **Two input values**: key (string) and value (string). **One output**: a json-formatted string.
      
      - DeleteRule. **One input values**: key (string). **One output**: a json-formatted string.

**How to run the tests**

The easiest way to run the tests is:
    - Clicking on **Test > Run All Tests**. The **Test Explorer should appear** with information about the test run.
    - Alternatively, under the test project, you can find the classes with tests inside. **You can trigger the tests by going to each method > right click on the name > Run Test**.
