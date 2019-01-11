SkyBrink Employee Management (C# asp.net MVC, Entity Framework)

Features:
1.	Dash board: Number of students department wise
2.	Dashboard: Number of instructors department wise
3.	nav bar: signup, log in, About this project, Technical Details
Signup:
1.	Email is already used or not, validation of entry fields, password hashing
Login:
1.	User authentication with database and redirect to the admin dashboard
Admin:
1.	Dashboard: Number of staffs per Faculty
2.	Dashboard: Revenue pie chart faculty wise for the year 2018
3.	Manage Staffs
1.	Show the lists of all employees (jQuery table): add, edit and delete operation
4.	Manage Students
1.	Show the list of all students (jQuery table): add, edit and delete operations
5.	Manage Instructors
1.	Show the list of all faculty members (jQuery table): add, edit and delete operations


Home Page & Dashboard
Steps: Create an MVC web project, configure database, adding custom layout and stylesheet and JavaScript
Custom Layout: In the project’s shared folder, create a MVC5 view page and then load your template code (default header, footer, etc.,) . Add css file as well and inside the new layout page identify it by typing:
<link rel="stylesheet" type="text/css" href="@Url.Content("~/Content/MyTemplate/")css/pricing.css" /> 
Now create the index html file for the controller. At the time of html file creation, select the layout file and add your desired template code inside the index.cshtml file
Database Design:
1.	Student: 
	First Name
	Last Name
	Department
	Email address
	Phone number
2.	Teacher: 
	First Name
	Last Name
	Department
	Email address
	Phone number
3.	Employee: 
	First Name
	Last Name
	Department
	Email address
	Phone number
	Designation
4.	Revenue:
	Department
	Profit
	Year

5.	User: 
	First Name
	Last Name
	Department
	Email address
	Phone number

Database Creation: Create a database inside the App_Data folder
Now, it is time to create 5 database tables.
Entity Framework:
Right click on the Models folder, add ADO.net Entity Data Model
Give a name like: MyModel, Select EF Designer from Database, click next, Select the created database, double check the generated connection string, click next, choose entity framework 6, Select all the tables from the database and finally click on the finish button.
5 new classes are created in the Models folder. Now it is the time to do the coding for controllers and view part
Now our target is to load the index dashboard where it will show two bar charts with number of students by department wise and number of teachers department wise.
For doing that, I  used rest API, AJAX and google chart. Index.cshtml has the code for ajax call and populate the charts for the dashboard. I created two additional classes TeacherResult and StudentResult for the ease of our work to format Json data. Two controllers were used: Home and Admin.

Some design specifications are as follows:
Dashboard 1(Public): 
 
Dashboard1 (Public):
 
Dashboard 2(Admin):
 
Employee Crud Operation: 
1.	Display all the employees:
 

2.	Add a new Employee:
 
3.	Edit an existing Employee:
 
4.	Delete an existing Employee:
 
5.	Technical summary from the website:
 

