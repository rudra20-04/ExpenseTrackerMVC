# 💰 Expense Tracker (ASP.NET Core MVC)

A **personal finance management system** built using **ASP.NET Core MVC** that allows users to manage their income, expenses, and visualize their spending through detailed reports and charts.

---

## 🚀 Features

✅ **User Authentication**
- Secure Login / Logout system  
- Role-based access (Admin / User)  

✅ **Dashboard**
- Overview of total income, expenses, and balance  

✅ **Expense & Income Management**
- Add, edit, and delete transactions  
- Categorize your income and expenses  

✅ **Reports & Analytics**
- Graphical visualization of income vs expenses  
- Filter reports by date and category  

✅ **Responsive & Modern UI**
- Clean and professional Bootstrap-based design  
- Attractive layout for all views (Login, Dashboard, Income, Expense, Reports)

---

## 🧩 Technologies Used

| Component | Technology |
|------------|-------------|
| **Framework** | ASP.NET Core MVC (.NET 8 / .NET 9) |
| **Database** |SQL Server(XAMPP)|
| **ORM** | Entity Framework Core |
| **Frontend** | HTML, CSS, Bootstrap, JavaScript |
| **IDE** | Visual Studio / VS Code |

---

## ⚙️ How to Run the Project

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-username/ExpenseTracker.git
cd ExpenseTracker
```

### 2️⃣ Open the Project
Open the folder in **Visual Studio** or **VS Code**.

### 3️⃣ Update Database Connection
In `appsettings.json`, update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ExpenseTrackerDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 4️⃣ Apply Database Migrations
```bash
dotnet ef database update
```

### 5️⃣ Run the Application
```bash
dotnet run
```

### 6️⃣ Open in Browser
Visit:
👉 [http://localhost:5000](http://localhost:5000)

Login with default credentials:
```
Username: admin  
Password: 123
```

---

## 📁 Folder Structure

```
ExpenseTracker/
│
├── Controllers/
│   ├── AccountController.cs
│   ├── ExpenseController.cs
│   ├── IncomeController.cs
│   └── ReportController.cs
│
├── Models/
│   ├── User.cs
│   ├── Expense.cs
│   ├── Income.cs
│   ├── Category.cs
│
├── Views/
│   ├── Account/
│   ├── Expense/
│   ├── Income/
│   ├── Report/
│   └── Shared/
│
├── Data/
│   └── AppDbContext.cs
│
├── wwwroot/
│   ├── css/
│   ├── js/
│
├── appsettings.json
└── Program.cs
```

---

## 🧠 Future Improvements

- Add monthly budget planner  
- Email notifications for large expenses  
- Export reports to Excel or PDF  

---

## 👨‍💻 Author

**Developed by:** [Patel Rudra M]
**GitHub:** [https://github.com/rudra20-04] 


---

## 🪪 License
This project is open-source and free to use for educational purposes.

---

