CREATE FUNCTION [dbo].[udf_CalculateTickets](@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS 
BEGIN 
	
	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!';

	DECLARE @FlightId INT = 
							(
								SELECT Id 
									FROM Flights 
									WHERE Origin = @origin AND Destination = @destination
							);

	IF(@FlightId IS NULL)
		RETURN 'Invalid flight!';

	DECLARE @TicketPrice DECIMAL(18,2) = 
										(
											SELECT Price
												FROM Tickets
												WHERE FlightId = @FlightId
										);
	RETURN 'Total price ' + CONVERT(VARCHAR, (@TicketPrice * @peopleCount));
END

