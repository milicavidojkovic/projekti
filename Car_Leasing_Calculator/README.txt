The Lease Calculator is a web application that allows users to calculate the leasing cost, 
down payment, monthly installment, and interest rate for a car lease based on user inputs. 
The application is built using HTML, CSS, and vanilla JavaScript.

Validation Rules
Car Value: Must be between €10,000 and €200,000. If the input is less than €10,000, an error message will be displayed, and calculations will not be performed.
Down Payment: Must be between 10% and 50%. If the input is less than 10%, an error message will be displayed, and calculations will not be performed.
Car Type: Must be selected to display the interest rate.

Calculation Formulas
Down Payment Amount
Down Payment Amount=(Down Payment Percentage/100)×Car Value
Monthly Installment
The formula to calculate the monthly installment is derived from the annuity formula:
𝑀=𝑃× (𝑟x(1+𝑟)^𝑛)/(1+𝑟)^(𝑛−1)
where:
M is the monthly installment
P is the principal amount (Car Value - Down Payment Amount)
r is the monthly interest rate (Annual Interest Rate / 12)
n is the number of payments (Lease Period in months)
​Total Leasing Cost
Total Leasing Cost=(Monthly Installment×Lease Period)+Down Payment Amount

Files
index.html: The main HTML file that contains the structure of the application.
style.css: The CSS file that contains styles for the application.
main.js: The JavaScript file that contains the logic for the application.