# 🍽 Restaurant Management System - Desktop Application

Welcome to the **Restaurant Management System**! 🎉 This project is a complete desktop application developed using **C# .NET Framework** in **Microsoft Visual Studio Community**. It’s designed to simplify restaurant operations by integrating various management features, including user management, order processing, kitchen tracking, reporting, and more! 🚀

##Introductury Vedio
`https://www.youtube.com/watch?v=aripIuUPO-Q&list=PL9PK4uQPgtnwIvaAJhQ6ZsdyzHMQkU5rv&index=1`
---

## ✨ Features
1. **User Management** 👤
   - Role-based access (e.g., Admin, Kitchen Staff, Waiter).
   - Login/Signup functionality 🔑.
   - Forget Password recovery system.

2. **Order Management** 🛒
   - Place, update, and track customer orders.
   - View order details.

3. **Kitchen Management** 🍳
   - Monitor pending and completed orders.
   - Streamline communication with kitchen staff.

4. **Reports** 📊
   - Total sales summary.
   - Inventory status (available items).
   - Detailed analytics for decision-making.

5. **Menu Management** 🗒️
   - Add, update, and remove menu items.
   - Manage item availability.

---

## 🛠️ Tech Stack
- **C# .NET Framework** for application development.
- **SQL Server** for database management.
- **Microsoft Visual Studio Community** as the IDE.

---

## 🚀 How to Run the Project
### Prerequisites:
1. Install **Microsoft Visual Studio Community**.
2. Install **SQL Server** and **SQL Server Management Studio (SSMS)**.
3. Clone this repository:
   ```
   git clone https://github.com/iimranirshad/Restaurant-Management-System.git
  
### Database Connection Setup:
The database connection string is located in the `MainClass.cs` file. By default, the connection string is as follows:

```
con_string = "Data Source = DESKTOP-1RQH46C\\SQLEXPRESS; Initial Catalog = TFC; Integrated Security=True";
```
### Email sending mechanism:
The email configuration file are located in model folder with name `email.cs` where you need to change these two things
```
public void Email(string toEmail)
        {
            string fromMail = "example@gmail.com";
            string fromPass = "secret-key";
...
```
#### Steps to Update the Connection String:
1. Open the `MainClass.cs` file.
2. Replace the default connection string with your own:
   - **Data Source**: Enter the name of your SQL Server instance.
   - **Initial Catalog**: Enter the name of the database (default: `TFC`).
   - **Integrated Security**: Use `True` for Windows Authentication or provide a username and password for SQL Authentication.

Example:
```
con_string = "Data Source = YOUR_SERVER_NAME; Initial Catalog = YOUR_DATABASE_NAME; Integrated Security=True";
```

3. Save the file and build the project.

### Running the Application:
1. Open the solution file (`.sln`) in Visual Studio.
2. Build the project (`Ctrl+Shift+B`).
3. Run the application (`F5`).


---

## 🗂️ Project Structure
- **MainClass.cs**: Contains the database connection string and utility methods.
- **Forms/**: Includes all UI forms like Login, Dashboard, Orders, Kitchen, etc.
- **Models/**: Database models and classes for easier data manipulation.
- **Reports/**: Code for generating and displaying reports.

---

## ❤️ Contributing
Feel free to fork this project, submit issues, or create pull requests. Let’s make this app even better together! 💪

---

## 📧 Contact
For any questions or suggestions, feel free to contact me at:
- **Email**: imranirshad002@gmail.com
- **GitHub**: (https://github.com/iimranirshad)

---

### 🌟 Don’t forget to star this repo if you like it! ⭐

Happy coding! 👨‍💻👩‍💻
