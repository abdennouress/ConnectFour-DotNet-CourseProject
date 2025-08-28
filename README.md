<a id="readme-top"> </a>

# 🎮 Connect Four – Client & Server Project
<p align= "center"><img width="300" alt="ConnectFourIcon" src="https://github.com/user-attachments/assets/0a726520-715e-4b81-9ff7-d85ccf635b56" /></p>




---

<h2><img src="https://github.com/YosiBs/Gotcha-App/assets/105666011/558f0957-6604-47a4-a202-66a02a2835e7" alt=pic5 width="40" height="40"> Overview</h2>
This project is an academic implementation of the classic **Connect Four** game with a **Client–Server architecture**.  

- **Client (WinForms)**: Provides a modern UI for playing Connect Four against the computer (server). Includes animations, replay functionality, and a Discord-inspired design theme.  
- **Server (ASP.NET Core)**: Manages the game logic, player registration, database, and queries. Supports multiple clients playing independently in parallel.  

The project demonstrates **full-stack development** in C#, combining a desktop application, ASP.NET Core Web App (Razor Pages), and ASP.NET Core Web API, along with SQL Server for persistent data storage.

---



## 📸 Screenshots

- Login Screen (Client)
<img width="300" height="632" alt="LoginForm" src="https://github.com/user-attachments/assets/da147442-1dd6-43df-baae-fdd86a394e42" />

- Game Board (Client)
<img width="350" alt="Game" src="https://github.com/user-attachments/assets/00ef2238-177b-411b-9755-d2df3087a0b7" />

- Replay List (Client)
<img width="300" alt="ReplayForm" src="https://github.com/user-attachments/assets/6d21adc4-aa8d-4abe-848e-9d43d1f8c44a" />

- Replay Display (Client)
<img width="300" alt="ReplayDisplay" src="https://github.com/user-attachments/assets/e7c0215e-e428-4cbe-af75-ebec1a75c938" />

- Razor Pages - Home Screen (Server Dashboard)
<img width="650"  alt="HomeScreen" src="https://github.com/user-attachments/assets/39a8470b-438b-4039-9afc-43e5f71cb548" />

- Razor Pages - ScoreBoard (Server Dashboard)
<img width="650" alt="PlayersData" src="https://github.com/user-attachments/assets/32cdaeba-94bd-4215-b13d-abc6ed649d63" />

---

<h2><img src="https://github.com/YosiBs/Pokemon-Escape-Mobile-Game/assets/105666011/008a508e-5484-46ba-be36-ac359d603f01" alt=pic5 width="40" height="40"> Features</h2>


- 🔹 Play **Connect Four** against the server.  
- 🔹 Player registration with validation (name, ID, phone, country).  
- 🔹 **Stylish WinForms Client** with Discord theme and animations.  
- 🔹 **Replay functionality** for past games saved locally.  
- 🔹 **Server Web Interface** (Razor Pages) for:
  - Registering players
  - Running queries
  - Viewing statistics & player information
  - Managing updates and deletions  
- 🔹 **REST API** (ASP.NET Core Web API) for client–server communication.  
- 🔹 **SQL Server Database**:
  - Stores players, games, and moves
  - Supports queries like:
    - All players (ordered case-sensitive)
    - All games with details
    - Distinct games without duplicates
    - Player statistics per country
    - Player participation counts  

---

<h2><img src="https://github.com/YosiBs/Gotcha-App/assets/105666011/f09bd9dd-b5e2-4076-a617-fd71fe7deceb" alt=pic5 width="40" height="40"> Technologies Used</h2>

- **C# .NET**  
- **WinForms** (Client UI)  
- **ASP.NET Core Razor Pages** (Server web app)  
- **ASP.NET Core Web API** (Server API)  
- **SQL Server LocalDB** (ADO.NET / Entity Framework)  
- **LINQ** for queries  
- **Bootstrap** (styling Razor pages)

---

## 🏗 Architecture

```mermaid
flowchart LR
    subgraph Client[🎮 Client - WinForms App]
        UI[UI - Game Board & Controls]
        Replay[Replay Saved Games]
    end

    subgraph Server[🖥 Server - ASP.NET Core]
        Razor[Razor Pages - Web UI]
        API[Web API - REST Endpoints]
    end

    subgraph Database[🗄 SQL Server LocalDB]
        Players[(Players Table)]
        Games[(Games Table)]
        Moves[(Moves Table)]
    end

    UI -->|HTTP Requests| API
    Replay -->|Local Saved Games| UI
    Razor --> Database
    API --> Database
```

<h2><img src="https://github.com/YosiBs/Gotcha-App/assets/105666011/9f5d6637-b1e1-4037-8f60-64388e5ab109" alt=pic5 width="40" height="40"> Authors</h2>

<ul>
    <li><a href="https://github.com/YosiBs">Yosi Ben Shushan</a></li>
    <li><a href="https://github.com/Noam0">Noam Ben Benjamin</a></li>
</ul>

---

<h2><img src="https://github.com/YosiBs/Gotcha-App/assets/105666011/65ede3d1-631b-4d43-801a-3c17777938fb" alt=pic5 width="40" height="40"> References</h2>

- [Connect Four inspiration game](https://www.cbc.ca/kids/games/all/connect-4)  
- [ASP.NET Core Razor Pages Documentation](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/page)  
- [ASP.NET Core Web API Documentation](https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client)  
- [Bootstrap Grid System](https://getbootstrap.com/docs/5.0/layout/grid/)  

---



<p align="right"><a href="#readme-top"><img src="https://github.com/user-attachments/assets/5390781c-77bb-4f30-8403-1f46f14f9058" alt=pic5 width="40" height="40"></a></p>
