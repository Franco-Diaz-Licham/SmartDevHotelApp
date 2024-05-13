namespace SmartDevHotelAppLibrary.Helpers;

public static class SqliteQueriesDictionary
{
    public static Dictionary<string, string> Booking { get; set; } = new()
    {
        { 
            "CheckIn", @"UPDATE Booking
	                     SET CheckedIn = 1
	                     WHERE Id = @Id;" 
        },
        { 
            "Insert", @"INSERT INTO Booking(RoomId, GuestId, StartDate, EndDate, TotalCost, CheckedIn)
	                    VALUES(@RoomId, @GuestId, @StartDate, @EndDate, @TotalCost, 0);"
        },
        {
            "Search", @"SELECT B.Id, B.RoomId, B.GuestId, B.StartDate, B.EndDate, B.CheckedIn, 
							   B.TotalCost, G.FirstName, G.LastName, R.RoomNumber, R.RoomTypeId, 
							   RT.Title, RT.Description, RT.Price
						FROM Booking AS B
						INNER JOIN Guest AS G ON B.GuestId = G.Id
						INNER JOIN Room AS R ON B.RoomId = R.Id
						INNER JOIN RoomType AS RT ON R.RoomTypeId = RT.Id
						WHERE B.StartDate = @StartDate 
						AND G.LastName = @LastName
						AND B.CheckedIn = @CheckedIn;"
        }
    };

    public static Dictionary<string, string> Guest { get; set; } = new()
    {
        { 
			"Insert", @"	INSERT INTO Guest(FirstName, LastName)
							VALUES(@FirstName, @LastName);" 
		},
		{
            "SelectByName", @"	SELECT G.Id, G.FirstName, G.LastName
								FROM Guest AS G
								WHERE G.FirstName = @FirstName 
								AND G.LastName = @LastName LIMIT 1;"
        }
    };

    public static Dictionary<string, string> Room { get; set; } = new()
    {
        { 
			"GetAvailableRooms", @" SELECT R.*
	                                FROM Room AS R
		                            INNER JOIN RoomType AS T ON T.Id = R.RoomTypeId
	                                WHERE R.RoomTypeId = @RoomTypeId
                                    AND R.Id NOT IN(
                                        SELECT B.RoomId 
                                        FROM Booking AS B
			                            WHERE (@StartDate < b.StartDate AND @EndDate > b.EndDate)
				                        OR (b.StartDate <= @EndDate AND @EndDate < b.EndDate)
				                        OR (b.StartDate <= @StartDate AND @StartDate < b.EndDate));"
		},
		{
			"Insert", @"INSERT INTO Room(RoomNumber, RoomTypeId)
						VALUES(@RoomNumber, @RoomTypeId);"
        }
    };

    public static Dictionary<string, string> RoomType { get; set; } = new()
    {
        { 
			"GetAvailableTypes", @"SELECT T.Id, T.Title, T.Description, T.Price
								 FROM Room AS R
								 INNER JOIN RoomType AS T ON T.Id = R.RoomTypeId
								 WHERE R.Id NOT IN (
									SELECT B.RoomId
									FROM Booking AS B
									WHERE (@StartDate < B.StartDate AND @EndDate > B.EndDate)
									OR (B.StartDate <= @EndDate AND @EndDate < B.EndDate)
									OR (B.StartDate <= @StartDate AND @StartDate < B.EndDate))
	                             GROUP BY
		                            T.Id, 
		                            T.Title, 
		                            T.Description, 
		                            T.Price;" 
		},
		{
            "Insert", @"INSERT INTO RoomType(Title, Description, Price)
						VALUES(@Title, @Description, @Price);"
        },
		{
            "SelectById", @"SELECT * 
							FROM RoomType AS RT
							WHERE RT.Id = @RoomTypeId;"
        }
    };
}
