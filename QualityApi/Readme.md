# Product Quality Tracker

## Outline
This project will require you to build a full stack application used to track Product Quality Cases in a retail store.

- Front end in Vite React Typescript
- Back end will be built in C# ASP.NET
- A database of products and cases in MySQL

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
- Outcome (Scrap, Repeair, Sell As Is or return to stock)
- recovered cost

Should there be another joining table to actually track the location and mount in Quality's inventory?

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

## MVP

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

## Extra goals:
- file upload?
- User Login
    - Access levels (Store level and Global level. Only Global can decide on the case outcome, only Local can make the initial case and carry out the given action).
- Warehouse storage visualisation based on the Storage Location column. Have a map of the warehouse that displays where pulled Quality affected products are being stored while under investigation.