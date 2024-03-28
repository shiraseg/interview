## Program Execution: F5

### Home Page:
The client can always return to the home page by clicking the HOME tab. (All tabs are part of the layout visible to the client throughout the execution)
![Home Page](https://github.com/shiraseg/interview/assets/92149110/33604bfd-35d6-4244-b986-e3a4b03ee287)

### Client Management:
The client can view a list of all clients, reports on patients and vaccinated individuals, and create a new client.
![Client Management](https://github.com/shiraseg/interview/assets/92149110/4dfed9ce-3b67-4869-8ed9-e2cc16a674d3)

### Patient List:
The list of all patients at the clinic contains filtered and relevant information. Next to each item, there is an option to view additional information not displayed in the summary list. Additionally, clients can be edited or deleted. This page includes an option to filter by client ID (complete or partial) as shown in the example:
![Patient List](https://github.com/shiraseg/interview/assets/92149110/a0676bd5-028c-4bf8-806a-b7ed25b19b93)

### Adding a New Client:
For adding a vaccine, there is an option to add up to a maximum of 4 vaccines. For adding a disease status, there is no limitation. If there is no desire to add a vaccine or disease status, the respective field remains untouched, and the values will be NULL, thus not being added.
![Adding a New Client](https://github.com/shiraseg/interview/assets/92149110/b574f21a-09a7-4d8c-81ac-2dfe3762eaab)

### Reports:
Tabs also include an option to view reports on activities performed in the last month:
![Reports](https://github.com/shiraseg/interview/assets/92149110/251c7df1-50e0-4459-9f52-5dcf605e87cd)

### Additional Details:
I have added validations and licenses to fieldsת by using animations and OnClick event plus using an alert().
I utilized ASP.NET CORE technology with an MVC architecture and Microsoft SQL Server as the database. To create the database, I had to create a DbContext class and perform an Inject to build the database. I decided that it is appropriate to create a PERSON model where the model has fields for a list of vaccines and a list of disease statuses. These fields are virtual and are not stored in the DATABASE to avoid overloading the PERSON table, but their significance is that during runtime, I can store an updated list of vaccines and disease statuses associated with a specific client.

I created a COVIDSTATUS model that saves the start date of the coronavirus disease and the recovery date. It has a FOREIGN KEY associated with PERSON. I also created a VACCINATION model that saves the type of vaccine (ENUM type) and the vaccination date. It also has a FOREIGN KEY associated with PERSON.

I created a controller for PERSON which includes references to all CRUD operations.
### Utilizing Scaffolded Controllers:
I utilized scaffolding to automatically generate controllers for managing CRUD operations. This streamlined the process, saving time and effort. However, adjustments were necessary to accommodate the unique aspects of my models. Specifically, I needed to manually manage the COVIDSTATUS and VACCINATION models within loops to ensure proper functionality.
![image](https://github.com/shiraseg/interview/assets/92149110/1f43d49c-419c-4204-9110-765027c8c9a3)


### Automatic Deletion Handling:
Thanks to CASCADE configuration in the database, I didn't need to manually handle deletion operations. CASCADE automatically deletes associated records in related tables when a record in the parent table is deleted. This simplified the deletion process, reducing the need for manual intervention.
