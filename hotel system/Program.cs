using System;

namespace SimpleHotelRoomManagement
{
    class Program
    {
        // Capacity & storage (parallel arrays)
        const int MAX_ROOMS = 100;

        static int[] roomNumbers = new int[MAX_ROOMS];
        static double[] roomRates = new double[MAX_ROOMS];
        static bool[] isReserved = new bool[MAX_ROOMS];
        static string[] guestNames = new string[MAX_ROOMS];
        static int[] nights = new int[MAX_ROOMS];
        static DateTime[] bookingDates = new DateTime[MAX_ROOMS];

        // number of rooms that have been added (not reservations)
        static int roomCount = 0;

        static void Main()//adding menu 
        {
            while (true)
            {
                Console.WriteLine("\n===== Hotel Room Management =====");//hotel room management system
                Console.WriteLine("1) Add a new room");//add a new room
                Console.WriteLine("2) View all rooms");//view all rooms
                Console.WriteLine("3) Reserve a room");//reserve a room
                Console.WriteLine("4) View all reservations");//view all reservation 
                Console.WriteLine("5) Search reservation by guest name");//search reservation by guest name
                Console.WriteLine("6) Find highest-paying guest");//find highest paying guest
                Console.WriteLine("7) Cancel a reservation by room number");//cancel reservation by room number
                Console.WriteLine("8) Exit");
                Console.Write("Choose (1-8): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1": AddRoom(); break;//case 1: add a new room
                    case "2": ViewAllRooms(); break; //case 2: view all rooms
                    case "3": ReserveRoom(); break; //case 3: reserve a room
                    case "4": ViewAllReservations(); break; //case 4: view all reservations
                    case "5": SearchByGuestName(); break;//case 5 : search reservation by guest name
                    case "6": HighestPayingGuest(); break;//case 6: find highest paying guest
                    case "7": CancelReservation(); break;//case 7: cancel reservation by room number
                    case "8":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-8.");
                        break;
                }
            }
        }

        // 1) Add a new room
        static void AddRoom()
        {
            if (roomCount >= MAX_ROOMS)// if the room count is greater than or equal to the maximum rooms allowed
            {
                Console.WriteLine("Capacity full. Cannot add more rooms.");
                return;
            }

            int number = ReadInt("Enter room number: ");// read the room number from the user
            // Unique number validation
            if (FindRoomIndex(number) != -1)//if the room number already exists
            {
                Console.WriteLine("Room number must be unique. This number already exists.");
                return;
            }

            double rate = ReadDouble("Enter daily rate (>= 100): ");
            if (rate < 100.0)//if the rate is less than 100
            {
                Console.WriteLine("Rate must be at least 100.");
                return;
            }

            roomNumbers[roomCount] = number;// store the room number in the array
            roomRates[roomCount] = rate;// store the room rate in the array
            isReserved[roomCount] = false;// set the room as not reserved
            guestNames[roomCount] = string.Empty;
            nights[roomCount] = 0;
            bookingDates[roomCount] = default;

            roomCount++;
            Console.WriteLine("Room added successfully.");
        }

        // 2) View all rooms
        static void ViewAllRooms()
        {
            if (roomCount == 0)
            {
                Console.WriteLine("No rooms added yet.");
                return;
            }

            Console.WriteLine("RoomNo  Rate    Status");
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < roomCount; i++)
            {
                if (!isReserved[i])
                {
                    Console.WriteLine($"{roomNumbers[i],-7} {roomRates[i],-7:0.00} Available");
                }
                else
                {
                    double total = nights[i] * roomRates[i];
                    Console.WriteLine($"{roomNumbers[i],-7} {roomRates[i],-7:0.00} Reserved by {guestNames[i]} | Total: {total:0.00}");
                }
            }
        }

        // 3) Reserve a room
        static void ReserveRoom()
        {
            if (roomCount == 0)
            {
                Console.WriteLine("No rooms exist. Add rooms first.");
                return;
            }

            Console.Write("Guest name: ");
            string? name = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Guest name cannot be empty.");
                return;
            }

            int number = ReadInt("Room number to reserve: ");
            int idx = FindRoomIndex(number);
            if (idx == -1)
            {
                Console.WriteLine("Room does not exist.");
                return;
            }
            if (isReserved[idx])
            {
                Console.WriteLine("Room is already reserved.");
                return;
            }

            int n = ReadInt("Number of nights (>0): ");
            if (n <= 0)
            {
                Console.WriteLine("Nights must be greater than 0.");
                return;
            }

            isReserved[idx] = true;
            guestNames[idx] = name;
            nights[idx] = n;
            bookingDates[idx] = DateTime.Now;

            double total = n * roomRates[idx];
            Console.WriteLine($"Reserved. Total cost = {total:0.00}");
        }

        // 4) View all reservations
        static void ViewAllReservations()
        {
            bool any = false;
            Console.WriteLine("Guest                Room  Nights  Rate     Total     Booked");
            Console.WriteLine("--------------------------------------------------------------------");
            for (int i = 0; i < roomCount; i++)
            {
                if (isReserved[i])
                {
                    any = true;
                    double total = nights[i] * roomRates[i];
                    Console.WriteLine($"{guestNames[i],-20} {roomNumbers[i],-5} {nights[i],-6} {roomRates[i],-7:0.00} {total,-8:0.00} {bookingDates[i]}");
                }
            }
            if (!any) Console.WriteLine("No reservations.");
        }

        // 5) Search reservation by guest name (case-insensitive)
        static void SearchByGuestName()
        {
            Console.Write("Enter guest name to search: ");
            string key = (Console.ReadLine() ?? "").Trim();

            bool found = false;
            for (int i = 0; i < roomCount; i++)
            {
                if (isReserved[i] && guestNames[i].Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    double total = nights[i] * roomRates[i];
                    Console.WriteLine($"Found: {guestNames[i]} | Room {roomNumbers[i]} | Nights {nights[i]} | Rate {roomRates[i]:0.00} | Total {total:0.00} | Booked {bookingDates[i]}");
                }
            }
            if (!found) Console.WriteLine("Not found.");
        }

        // 6) Highest-paying guest
        static void HighestPayingGuest()
        {
            double maxTotal = -1;
            int maxIndex = -1;

            for (int i = 0; i < roomCount; i++)
            {
                if (isReserved[i])
                {
                    double total = nights[i] * roomRates[i];
                    if (total > maxTotal)
                    {
                        maxTotal = total;
                        maxIndex = i;
                    }
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine("No reservations yet.");
                return;
            }

            Console.WriteLine($"Highest-paying guest: {guestNames[maxIndex]}");
            Console.WriteLine($"Room: {roomNumbers[maxIndex]}, Nights: {nights[maxIndex]}, Rate: {roomRates[maxIndex]:0.00}, Total: {maxTotal:0.00}");
        }

        // 7) Cancel reservation by room number
        static void CancelReservation()
        {
            int number = ReadInt("Enter room number to cancel: ");
            int idx = FindRoomIndex(number);
            if (idx == -1)
            {
                Console.WriteLine("Room does not exist.");
                return;
            }
            if (!isReserved[idx])
            {
                Console.WriteLine("This room is not reserved.");
                return;
            }

            isReserved[idx] = false;
            guestNames[idx] = string.Empty;
            nights[idx] = 0;
            bookingDates[idx] = default;

            Console.WriteLine("Reservation cancelled.");
        }

        // Helpers
        static int FindRoomIndex(int roomNumber)
        {
            for (int i = 0; i < roomCount; i++)
                if (roomNumbers[i] == roomNumber) return i;
            return -1;
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double v)) return v;
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
