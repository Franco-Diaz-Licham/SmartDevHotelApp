# Description
Smart Dev Hotel Application is a Windows Presentation Foundation (WPF) desktop application that allows staff users of a small hotel company to view and book available hotel rooms as guests arrive. 
This application is to be used as an internal application for a small hotel company, having a directory for users, ability to create rooms and notify users via email that their room is ready for check in.

The application uses MSSQL for the Database and data access using Dapper as the ORM via stored procedures for greater control of data querying according to application needs. 
Looking to introduce basic authentication so that information is hiden behind a login.

This application was completed as a practice project based on Tim Corey's course on C# Application Development.

# Overview
The application currently has 7 forms:

1. Main Window: Main menu

![MainWindow](https://github.com/Franco-Diaz-Licham/SmartDevHotelApp/assets/138960498/e2fe21d4-ce5d-4fac-b5a8-58b01b6bd2b8)

2. Room Searh Form: allows users to search for available rooms that have not been booked.

![RoomSearch](https://github.com/Franco-Diaz-Licham/SmartDevHotelApp/assets/138960498/a65a88b1-8e1f-468f-a368-601978976ff8)

3. Search Bookings Form: allows users to search for booked rooms.

![SearchBookings](https://github.com/Franco-Diaz-Licham/SmartDevHotelApp/assets/138960498/f6188c81-c97e-4b48-90cd-eed31ca97ac6)

4. Checkin Form: confirmation form for guest check in.

![CheckIn](https://github.com/Franco-Diaz-Licham/SmartDevHotelApp/assets/138960498/ceaf19a2-47bc-42e3-b786-a10e2f3a5720)

5. Booking Form: allows users to book room for guest by entering their details.

![Booking](https://github.com/Franco-Diaz-Licham/SmartDevHotelApp/assets/138960498/fa342b1a-4f98-4cae-a0d8-0663585d16a0)

6. Guest Management Form: To be completed


7. Room Management Form: To be completed
