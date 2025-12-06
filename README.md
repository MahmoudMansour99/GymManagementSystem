# 🏋️‍♂️ Power Fitness – Gym Management System

A complete **Gym Management System** built using **ASP.NET MVC, Entity Framework Core, and SQL Server**.  
The system provides role-based access (Super Admin & Admin) and includes full management of Members, Trainers, Sessions, and Plans, along with an analytics dashboard.

This project is designed as a clean and professional MVC application following layered architecture with Services, Repositories, and the Unit of Work pattern.
______________________________________________________________________________________________________________________________________________________________________________________________________
## 🚀 Features

### 🔐 Authentication & Roles
- Login system with two predefined roles:
  - **Super Admin**
  - **Admin**
- Each role has access to specific management pages.

### 🏠 Dashboard (Home Page)
- Displays key analytics:
  - Total Members
  - Active Members
  - Total Trainers
  - Upcoming Sessions
  - Ongoing Sessions
  - Completed Sessions
  - Other system insights

### 👥 Member Management
- Add new members
- Edit existing members
- View member details
- View Health Data Records
- Delete members

### 🏋️ Trainer Management
- Add trainer
- Edit trainer
- View trainer info
- Delete trainer

### 📅 Session Management
- Create new session
- Edit session details
- Delete session
- Automatic generation of start & end dates based on plan duration

### 📦 Plan Management
- Add new plan
- Edit plan details
- Activate or Deactivate plans

### 🔓 Logout Functionality
- Secure logout for both roles

_____________________________________________________________________________________________________________________________________________________________________________________________________
  
## 🛠 Tech Stack

### 🔧 Backend
- **ASP.NET MVC 9**
- **C#**
- **Entity Framework Core**
- **LINQ**
- **AutoMapper**
- **Repository Pattern**
- **Unit of Work Pattern**

### 🗄 Database
- **Microsoft SQL Server**
- EF Core Migrations for schema creation
- Supports SQL `.bak` script for setup

### 🎨 Frontend
- **Bootstrap 5.3**
- **jQuery**
- **Bootstrap Icons**
- Custom CSS for enhanced UI/UX

### ⚙️ Development Tools
- Visual Studio 2022
- SQL Server Management Studio (SSMS)
- Git & GitHub

____________________________________________________________________________________________________________________________________________________________________________________
## 📸 Screenshots

### 🔑 Login Page
![Login](Gym%20System%20Design/login.png)

### 🏠 Dashboard (Home Page)
![Dashboard](Gym%20System%20Design/Login%20Page/Login%20Page.png)

### 👥 Members Page
![Members List](Gym%20System%20Design/Member%20Page/Member%20Page%2001.png)
![Add Member](Gym%20System%20Design/Member%20Page/Member%20Page%2002%20-%20Add%20Member%20Section.png)
![View Member Data](Gym%20System%20Design/Member%20Page/Member%20Page%2003%20-%20View%20Member%20Data%20Section.png)
![View Member Health Record](Gym%20System%20Design/Member%20Page/Member%20Page%2004%20-%20View%20Member%20Health%20Record%20Data%20Section.png)
![Edit Member](Gym%20System%20Design/Member%20Page/Member%20Page%2005%20-%20Edit%20Member%20Data%20Section.png)

### 🏋️ Trainers Page
![Trainers List](Gym%20System%20Design/Trainer%20Page/Trainer%20Page%2001.png)
![Add Trainer](Gym%20System%20Design/Trainer%20Page/Trainer%20Page%2002%20-%20Add%20Trainer%20Section.png)
![Edit Trainer](Gym%20System%20Design/Trainer%20Page/Trainer%20Page%2004%20-%20Edit%20Trainer%20Data%20Section.png)

### 📅 Sessions Page
![Sessions List](Gym%20System%20Design/Session%20Page/Session%20Page%2001.png)
![Add Session](Gym%20System%20Design/Session%20Page/Session%20Page%2002%20-%20Add%20Session.png)
![Edit Session](Gym%20System%20Design/Session%20Page/Session%20Page%2004%20-%20Edit%20Session%20Section.png)

### 📦 Plans Page
![Plans List](Gym%20System%20Design/Plan%20Page/Plan%20Page%2001.png)
![View Plan](Gym%20System%20Design/Plan520Page/Plan%20Page%2003%20-%20Edit%20Plan%20Section.png)
![Activate/Deactivate Plan](Gym%System%20Design/Plan%20Page/Plan%20Page%2004%20-%20Edit%20Status%20Plan%20Section.png)

### 🔓 Logout Button
![Logout](Gym%20System%20Design/Home%20Page/Home%20Page%2001.png)

_________________________________________________________________________________________________________________________________________________________________________________
## 🔑 Demo Login Credentials

**Super Admin**
- Email: MahmoudMansour@gmail.com
- Password: P@ssw0rd

**Admin**
- Email: HassanMansour@gmail.com
- Password: P@ssw0rd

> These are the test accounts anyone can use to access the system.
