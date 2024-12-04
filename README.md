# Quality Case Tracker Application

This full stack project is purely made as a hobby project and is not licensed or created for any specific retail store/organization. It is however inspired by an application that I wish existed in my old job when I worked in Product Quality. I no longer work in that position, but I saw this as a fun challenge to tackle a problem that I personally found frustrating.

So originally this started as a way to familiarise myself with C# before a job interview before ditching it for a project with a much smaller scope. I then decided it would be a great project to work on in my own time to practice going through the full Software Development Lifecycle.
My approach for this has been to emulate the creation of a full product from begining to end as if I am creating this for a large client. I've staged mock User Interviews, created a ticket board with User Stories, and I'm creating Figma wireframes to plan out my front end.

## User Interviews
To ground this project in reality I conducted some user interviews with six people who still worked either in the role or in adjacent roles. These users are represented with the numbers **1-6**, **1** being someone who would be the main user of this product (the person that is currently in my old role) and **6** is a user working in a completely different department who might benefit from occasional use of the application.

### Roles
- **1** Current Product Quality Manager
- **2** Former Product Quality Manager, current Quality team member
- **3** Long time Quality team member
- **4** Customer Contact Centre team member, former Quality team member
- **5** Retail Sales Manager
- **6** Retail Sales Assistant

### Questions
#### Q: How does Product Quality tie into your daily workflow?
- **1**: It is the core of my role and my responsibility. I'm the team leader that manages cases and assigns work to the team.
- **2**: Quality is about half of what I do. I'm usually fielding Returns desk questions.
- **3**: I'm not in charge but I'm the most experienced with it. People are often referred to me when there is a Quality issue. I'm usually carrying out the actions once the cases are resolved.
- **4**: I get at least 3 customers a week claiming a quality issue with a customer. I don't get to determine if it is a confirmed Quality issue but I do decide if the issue gets escalated and passed on to Quality. 
- **5**: It can affect me and my team when my stock is unavailable 
- **6**: Maybe think about it a couple of times a month if I notice a potential product issue.

#### Q: What is a frustration that you have with the current way that Product Quality works?
- **1**: I find it really difficult to keep track of all of the pending actions. Some team members accept the actions without updating the spreadsheet which removes the case from the queue. I've had cases in storage that I hadn't realised had been released weeks previously until I'd done an audit.
- **2**: Explaining to Management why we do things. Feels like a presentation has to be made every time stock is pulled
- **3**: *NA*
- **4**: Not enough people are aware of what the Quality team actually does so defects either go unreported or coworkers report everything as a quality defect.
- **5**: I would really like more transparency and communication on Quality
- **6**: I don't understand Quality's job very well, it would be nice to be able to get a bit more context on why products get taken off the floor.

#### Q: If Product Quality had a centralised application that you had access to what features would you find useful?
- **1**: Some way I can search cases based on the defect. Also an easy way to check for any updates/resolutions within the last week or month.
- **2**: An action planner so we can see what jobs need to be completed. Sustainability figures. 
- **3**: figure out some way to link cases to the warehouse storage location management systems. Would be much easier to manage and keep up to date if they were linked. 
- **4**: Would honestly just be nice to have access to a record of cases. Would help make informed decisions on whether or not a customer is complaining about a legitimate Quality issue if I can see reoccuring issues.
- **5**: I think it would be nice to have some reports that people outside of Quality can access. Maybe status reports on cases so we know when stock will be available for customers again.
- **6**: Just being able to access information on why products are being pulled. 

### Findings
From what I gathered from my discussions with the different users there seemed to be a need for better search capabilities, visualisation and transparancy. I can use a library like Chart.js to create some really easy to digest visualisations of data. 
Anything more indepth can be accessed by searching through cases. 

I also don't want this application to only be a tool used by the Quality Team. Giving access to Retail Sales and the Call Center would probably make their jobs a little easier. If they get a better examples of what Quality does then they can also assist Quality in being proactive with finding defects.

These findings would help me write User Stories when creating tickets on my Project Board.

---

## MVP Proposal

After conducting the User Interviews I wrote up a proposal for the Minimum Viable Product. This is pretty much the exact document I sent off to a mentor with some small adjustments after a short discussion. 

### Outline

This project will require you to build a full stack application used to track Product Quality Cases in a retail store.

- Front end in Vite React Typescript
- Back end will be built in C# ASP.NET
- A database of products and cases in MySQL *(This has since been changed to Postgres)*

Products should contain:
- a name
- a SKU (barcode number)
- a department
- cost price (this would be the cost that the supplier sells the product to the store for)
- retail price (this is the amount the store sells it to their customers)
- unit weight of a single product
- quantity in stock
- All of the cases it has been involved in (join Case table (one-to-many))

Cases should contain:
- Case number
- Product Id
- Product (join Product table)
- Description
- Case Start Date
- Quantity of affected stock
- Storage Location (unique value)
- $ amount in cost price
- Is the case still active?
- End date of case
- Outcome (Scrap, Repeair, Sell Seconds or return to stock)
- recovered cost

Should there be another joining table to actually track the location and amount in Quality's inventory? *(I did end up adding this in the end)*

What are we tracking?
    Currently active and complete cases
	The amount of quality reports done each month
	The amount of quality requests completed
	the amount of stock stored in invent
	the amount that gets released (we get 100% value back)
	the amount that gets repaired (we only get the repair cost back)
	the amount that gets sold as seconds (we get 50% value back)
	the amount that gets thrown out (we get 100% value back plus scrapping fee (to be calculated by kilos)).

Bussiness Logic to consider:
- Depending on the given outcome of the case a different percentage of the cost is recovered/reimbursed. 
- If a product has 3 reports made on it it should be flagged.
- When products are pulled from store stock and put into inventory stock this should be reflected in both tables.

### MVP

at minimum your tracker should be able to:

- create and maintain a database with a table of Cases and a table of Products from different departments.
    - The table of products should be linked by a joining table of cases

- Should have a page of Cases
    - Cases should each have a link that will lead to a Case page with further information
    - Should be able to search cases by Case number, product name or SKU

- Should be able to update cases
    - When a case is updated and marked as resolved it should start a count-down. The Quality Team has a fortnight to carry out the action given.
        - once that action is completed there should be a check box or decleration. 
- When Affected stock qualtity is input/updated into the Cases table it should update the Quantity in stock on the Products table. 

- There should be a dashboard page that can visualise data over a span of time (month/year)
    - Cases started 
    - cases completed 
    - costs recovered and how they are recovered.
    - A cost recovery index (percentage of costs recovered vs costs to the store)
    - Total weight of stock scrapped (lower number is better)

- a calendar to track action deadlines.

---

## Wireframes

29/11/2024 - As of right now this is the step I'm currently on. I'm using Figma to create some simple wireframes for my web application. 

Here is my basic wireframe for my Cases Page. 
![Image](https://github.com/user-attachments/assets/d1472112-fd1e-41cf-87d2-358d7e048a70)

---

## Build Steps

- Coming Soon

---

## Design Goals / Approach

- This application should be intuitive and easy to use.
- This will be an internal application for a retail organisation. 
- This application will be used primarily by the Quality Team.
    - But other Teams/Managers will be able to access and view it to gain updates and insights on products and cases.

---

## Features

- Lists Cases and gives the user the ability to search/filter
- Data visualisation 
- Case Creation

---

## Known issues

- This is still in it's early development phase and is missing most of it's key features currently.
- Testing not yet implemented.

---

## Future Goals

Once the MVP is completed some extra features I would like to add will be:
- file upload
- User Login
    - Access levels (Store level and Global level. Only Global can decide on the case outcome, only Local can make the initial case and carry out the given action).
- Warehouse storage visualisation based on the Storage Location column. Have a map of the warehouse that displays where pulled Quality affected products are being stored while under investigation.

---

## Change logs

### 04/12/2024 - Created Update method
- Created Method to update cases
- Created Pageable Wrapper to wrap GET method results in

### 03/12/2024 - Created delete method
- Created Method to delete cases

### 26/11/2024 - Added basic cases table
- Created a basic cases table component for the front end.
    - Using React Query to fetch data for it.
- Also made the case create form functional.

### 22/11/2024 - Removed redundant CaseNumber column
- Realise CaseNumber was kind of redundant at the moment. Case ID works just fine.

### 21/11/2024 - Added front end
- Started to build the front end of the application
    - Landing Page and Create Case Form
    - Also created services

### 20/11/2024 - Swapped database over to Postgres
- Switched database over from MySQL to Postrgres
- Also fixed some issues with repetative JSON values in the data

### 18/11/2024 - Fixed issue with Case and Location Relationships
- 

### 15/11/2024 - Added Location Entity 
- Added Location Entity
    - After conducting a User Interview it was brought up that missing storage location data was a pain point for a couple of users. All cases will now have a storage location for the stock.

### 07/11/2024 - Initial commit
- Started with the creation of Product and Case Entities

---