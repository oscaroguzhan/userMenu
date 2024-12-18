# Instructions 
I denna övningsuppgift ska du skapa en enkel applikation som använder sig av service pattern och implementerar interfaces, arv och/eller abstrakta klasser. Övningen syftar till att förstå hur man kan designa en applikation som följer SOLID-principerna.



Instruktioner
Mål: Skapa en service som hanterar information om olika typer av användare (Users), där arv och/eller abstrakta klasser används för att strukturera koden.



1. Skapa en basklass och derived klasser för användare
   Skapa en abstrakt klass UserBase med följande egenskaper och metoder:
   int Id
   string Name
   abstract string GetRole(): Returnerar användarens roll.
   Skapa två klasser som ärver från UserBase:
   AdminUser: Implementerar metoden GetRole och returnerar "Admin".
   RegularUser: Implementerar metoden GetRole och returnerar "Regular".


2. Skapa ett interface för UserService
   Skapa ett interface IUserService med följande metoder:
   void AddUser(UserBase user): Lägger till en användare.
   UserBase GetUserById(int id): Hämtar en användare baserat på ID.
   List<UserBase> GetAllUsers(): Hämtar alla användare.


3. Implementera UserService
   Skapa en klass UserService som implementerar IUserService.
   Använd en lista (List<UserBase>) för att lagra användarna.
   Implementera metoderna enligt följande:
   AddUser: Lägger till användaren i listan.
   GetUserById: Returnerar användaren med matchande ID eller kastar ett undantag om användaren inte finns.
   GetAllUsers: Returnerar alla användare.