using eMovies.Enums;
using eMovies.Models;

namespace eMovies.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();


            //Cinema
            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema()
                    {
                        Name = "Starlight Cinema",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "An elegant cinema offering a luxurious experience with state-of-the-art sound and visuals. Located in the heart of the city, Starlight is perfect for movie lovers who seek comfort and quality.",
                        Location = "Downtown, Star Avenue 10",
                        ContactEmail = "info@starlightcinema.com",
                        PhoneNumber = "+359 212 345 678",
                        OpeningHours = "10:00 AM - 12:00 AM",
                        Capacity = 250,
                        Website = "http://www.starlightcinema.com"
                    },
                    new Cinema()
                    {
                        Name = "CineVerse",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "A modern cinema with futuristic design and immersive viewing experiences. Specializing in 3D and IMAX screenings, CineVerse offers a unique way to watch the latest blockbusters.",
                        Location = "Tech Park, Innovation Blvd 4",
                        ContactEmail = "contact@cineverse.com",
                        PhoneNumber = "+359 221 456 789",
                        OpeningHours = "09:30 AM - 11:30 PM",
                        Capacity = 320,
                        Website = "http://www.cineverse.com"
                    },
                    new Cinema()
                    {
                        Name = "Retro Films Cinema",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "A nostalgic cinema dedicated to classic films from the golden age of Hollywood. Enjoy timeless masterpieces in a vintage theater with modern amenities.",
                        Location = "Old Town, Classic Square 5",
                        ContactEmail = "info@retrofilms.com",
                        PhoneNumber = "+359 233 567 890",
                        OpeningHours = "11:00 AM - 10:00 PM",
                        Capacity = 150,
                        Website = "http://www.retrofilms.com"
                    },
                    new Cinema()
                    {
                        Name = "Green Horizon Cinema",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "Eco-friendly cinema with solar-powered lights and sustainable materials. Enjoy the best films while minimizing your environmental footprint.",
                        Location = "Green Hill, Eco Park 3",
                        ContactEmail = "contact@greenhorizoncinema.com",
                        PhoneNumber = "+359 245 678 901",
                        OpeningHours = "09:00 AM - 10:30 PM",
                        Capacity = 180,
                        Website = "http://www.greenhorizoncinema.com"
                    },
                    new Cinema()
                    {
                        Name = "The Velvet Screen",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "An intimate cinema known for its luxurious velvet seats and exclusive screenings. The Velvet Screen is perfect for private events and a premium movie night out.",
                        Location = "Fashion District, Velvet Lane 7",
                        ContactEmail = "info@velvetscreen.com",
                        PhoneNumber = "+359 256 789 012",
                        OpeningHours = "01:00 PM - 12:00 AM",
                        Capacity = 100,
                        Website = "http://www.velvetscreen.com"
                    }
                });
                context.SaveChanges();
            }



            //Actors
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                {
                    new Actor()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Bio = "A versatile actor known for his dramatic and comedic roles, starting in theater before moving to film.",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                    },
                    new Actor()
                    {
                        FirstName = "Sarah",
                        LastName = "Williams",
                        Bio = "A rising star in action films, known for her role in ‘The Last Stand’, which gained her international recognition.",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                    },
                    new Actor()
                    {
                        FirstName = "James",
                        LastName = "Smith",
                        Bio = "Known for his powerful performances in indie and blockbuster films, James brings raw emotion to the screen.",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                    },
                    new Actor()
                    {
                        FirstName = "Olivia",
                        LastName = "Miller",
                        Bio = "A veteran actress celebrated for her portrayal of complex characters in drama films over the past two decades.",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                    },
                    new Actor()
                    {
                        FirstName = "Daniel",
                        LastName = "Johnson",
                        Bio = "A charismatic actor known for comedies and romantic films, with a style that resonates with audiences worldwide.",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                    }
                });
                context.SaveChanges();
            }



            //Producers
            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>()
                {
                    new Producer()
                    {
                        FirstName = "Steven",
                        LastName = "Spielberg",
                        Bio = "Steven Spielberg is one of the most influential directors in the history of film, known for directing iconic movies such as 'Jaws', 'E.T.', and 'Schindler's List'.",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                    },
                    new Producer()
                    {
                        FirstName = "Kathleen",
                        LastName = "Kennedy",
                        Bio = "Kathleen Kennedy is a legendary producer, known for producing major blockbusters like 'Jurassic Park' and 'Star Wars' sequels.",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                    },
                    new Producer()
                    {
                        FirstName = "George",
                        LastName = "Lucas",
                        Bio = "George Lucas is best known for creating the 'Star Wars' and 'Indiana Jones' franchises, which have had a lasting impact on the film industry.",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                    },
                    new Producer()
                    {
                        FirstName = "Quentin",
                        LastName = "Tarantino",
                        Bio = "Quentin Tarantino is known for his distinctive filmmaking style, characterized by nonlinear storytelling and sharp dialogue. Films like 'Pulp Fiction' and 'Kill Bill' define his career.",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                    },
                    new Producer()
                    {
                        FirstName = "Emma",
                        LastName = "Thomas",
                        Bio = "Emma Thomas is an acclaimed producer, known for her collaborations with Christopher Nolan on films like 'Inception' and 'The Dark Knight Trilogy'.",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                    }
                });
                context.SaveChanges();
            }


            // Movies
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                {
                    new Movie()
                    {
                        Title = "The Adventure Begins",
                        Description = "A group of unlikely heroes set off on a thrilling journey to save the world. Packed with action, suspense, and heartwarming moments.",
                        Price = 12.99,
                        MovieImageURL = "https://static.wikia.nocookie.net/ttte/images/f/fb/TheAdventureBeginscover.jpg/revision/latest?cb=20190831120432",
                        StartDate = new DateTime(2024, 5, 1),
                        EndDate = new DateTime(2024, 5, 30),
                        Category = MovieCategory.Action,
                        CinemaId = 1,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "Whispers in the Dark",
                        Description = "A psychological thriller where a detective is drawn into a web of mysteries surrounding a string of bizarre disappearances.",
                        Price = 9.99,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BYjc0MzFkZmMtNDg2MS00Y2ViLThmYmItZTkyZTUxZjUzNTYzXkEyXkFqcGc@._V1_.jpg",
                        StartDate = new DateTime(2024, 6, 5),
                        EndDate = new DateTime(2024, 6, 25),
                        Category = MovieCategory.Thriller,
                        CinemaId = 2,
                        ProducerId = 2
                    },
                    new Movie()
                    {
                        Title = "Galactic Voyage",
                        Description = "In a futuristic world, a group of astronauts embarks on an intergalactic journey to explore distant planets, encountering unexpected challenges.",
                        Price = 14.99,
                        MovieImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQU2aZ9RWSGn8IWqZux_RpVqNXjrIUey8DfDA&s",
                        StartDate = new DateTime(2024, 7, 15),
                        EndDate = new DateTime(2024, 8, 10),
                        Category = MovieCategory.ScienceFiction,
                        CinemaId = 3,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "Falling Leaves",
                        Description = "A poignant drama about love, loss, and redemption, set against the backdrop of a small countryside town during the changing seasons.",
                        Price = 11.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                        StartDate = new DateTime(2024, 8, 20),
                        EndDate = new DateTime(2024, 9, 10),
                        Category = MovieCategory.Drama,
                        CinemaId = 4,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "Beyond the Horizon",
                        Description = "A family adventure film that explores the magic of nature and the power of belief as a young boy embarks on a life-changing adventure.",
                        Price = 10.99,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                        StartDate = new DateTime(2024, 9, 5),
                        EndDate = new DateTime(2024, 9, 30),
                        Category = MovieCategory.Horror,
                        CinemaId = 5,
                        ProducerId = 5
                    },
                    new Movie()
                    {
                        Title = "The Phantom Rift",
                        Description = "A mind-bending thriller that takes the audience on a journey through a world of parallel realities.",
                        Price = 13.99,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                        StartDate = new DateTime(2024, 10, 1),
                        EndDate = new DateTime(2024, 10, 25),
                        Category = MovieCategory.Thriller,
                        CinemaId = 3,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "Solar Flare",
                        Description = "A gripping sci-fi epic about the last hope for humanity after the sun starts to die.",
                        Price = 15.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-9.jpeg",
                        StartDate = new DateTime(2024, 10, 15),
                        EndDate = new DateTime(2024, 11, 10),
                        Category = MovieCategory.ScienceFiction,
                        CinemaId = 2,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "Crimson Shadow",
                        Description = "A gothic horror mystery following a young woman who discovers a dark secret about her family's legacy.",
                        Price = 12.50,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-10.jpeg",
                        StartDate = new DateTime(2024, 11, 1),
                        EndDate = new DateTime(2024, 11, 30),
                        Category = MovieCategory.Horror,
                        CinemaId = 3,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "Invisible Forces",
                        Description = "A sci-fi thriller where scientists discover a way to manipulate gravity, leading to a chain of dangerous events.",
                        Price = 13.50,
                        MovieImageURL = "https://sunypress.edu/var/site/storage/images/books/i/invisible-forces/9781438495774_cover/7102950-1-eng-CA/9781438495774_cover1_rb_modalcover.jpg",
                        StartDate = new DateTime(2024, 11, 5),
                        EndDate = new DateTime(2024, 11, 30),
                        Category = MovieCategory.ScienceFiction,
                        CinemaId = 5,
                        ProducerId = 2
                    },
                    new Movie()
                    {
                        Title = "Whispers from the Past",
                        Description = "A suspenseful drama where a young historian uncovers a hidden secret that threatens to change the course of history.",
                        Price = 10.99,
                        MovieImageURL = "https://m.media-amazon.com/images/I/81i9EYrsCZL._AC_UF1000,1000_QL80_.jpg",
                        StartDate = new DateTime(2024, 12, 1),
                        EndDate = new DateTime(2024, 12, 20),
                        Category = MovieCategory.Thriller,
                        CinemaId = 2,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "Time Traveler's Journey",
                        Description = "A time-travel adventure where a scientist goes back in time to save the future from a catastrophic event.",
                        Price = 15.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BMmEwYmRmYWYtYWMwZS00NDk1LWI3NGEtZDVmM2Y4OGM5NzM2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                        StartDate = new DateTime(2024, 12, 10),
                        EndDate = new DateTime(2024, 12, 30),
                        Category = MovieCategory.Action,
                        CinemaId = 5,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "Echoes of Eternity",
                        Description = "An epic fantasy tale where an ancient evil is awakened, and a group of heroes must unite to save the world.",
                        Price = 16.00,
                        MovieImageURL = "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781804073605/echoes-of-eternity-9781804073605_hr.jpg",
                        StartDate = new DateTime(2024, 12, 15),
                        EndDate = new DateTime(2025, 1, 5),
                        Category = MovieCategory.Fantasy,
                        CinemaId = 1,
                        ProducerId = 5
                    },
                    new Movie()
                    {
                        Title = "Undercover Storm",
                        Description = "A high-stakes thriller where a detective goes undercover to infiltrate a dangerous criminal syndicate.",
                        Price = 14.50,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BNTczNzAwNzE1Nl5BMl5BanBnXkFtZTgwNjc4NzE4NTE@._V1_FMjpg_UX1000_.jpg",
                        StartDate = new DateTime(2025, 1, 1),
                        EndDate = new DateTime(2025, 1, 25),
                        Category = MovieCategory.Thriller,
                        CinemaId = 2,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "Rise of the Titans",
                        Description = "A war between ancient gods and titans threatens to destroy the world, and only a chosen one can prevent the apocalypse.",
                        Price = 17.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BMTU0YTUwOGMtZDM5MS00ZGVkLWEzMDAtOWM2NTA1YTFiYWY5XkEyXkFqcGc@._V1_.jpg",
                        StartDate = new DateTime(2025, 1, 10),
                        EndDate = new DateTime(2025, 2, 5),
                        Category = MovieCategory.Fantasy,
                        CinemaId = 5,
                        ProducerId = 2
                    },
                    new Movie()
                    {
                        Title = "The Last Stand",
                        Description = "An action-packed drama where a small town sheriff must stand up against a criminal gang threatening to take over.",
                        Price = 12.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BODc4NjI0OTYwNl5BMl5BanBnXkFtZTcwOTYwODQ3OA@@._V1_.jpg",
                        StartDate = new DateTime(2025, 2, 1),
                        EndDate = new DateTime(2025, 2, 20),
                        Category = MovieCategory.Action,
                        CinemaId = 3,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "The Secret of the Labyrinth",
                        Description = "A group of explorers uncovers an ancient labyrinth full of dangerous traps and mystical secrets.",
                        Price = 13.99,
                        MovieImageURL = "https://www.filmfrance.net/app/uploads/2023/09/P_1_00863.jpg",
                        StartDate = new DateTime(2025, 2, 5),
                        EndDate = new DateTime(2025, 2, 25),
                        Category = MovieCategory.Adventure,
                        CinemaId = 4,
                        ProducerId = 2
                    },
                    new Movie()
                    {
                        Title = "Shadows of the Lost City",
                        Description = "A detective uncovers a conspiracy involving a hidden city beneath the streets of an ancient metropolis.",
                        Price = 14.50,
                        MovieImageURL = "https://m.media-amazon.com/images/I/81atBpLSbOL._UF1000,1000_QL80_.jpg",
                        StartDate = new DateTime(2025, 2, 10),
                        EndDate = new DateTime(2025, 2, 28),
                        Category = MovieCategory.Mystery,
                        CinemaId = 2,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "Wings of Freedom",
                        Description = "An inspiring drama about a young woman who becomes a pilot during WWII and fights for freedom in the skies.",
                        Price = 16.50,
                        MovieImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQ8BFHlpjXvWqQhxdHJ2KH5Y_GyIZ3pKDmkA&s",
                        StartDate = new DateTime(2025, 2, 15),
                        EndDate = new DateTime(2025, 3, 5),
                        Category = MovieCategory.Drama,
                        CinemaId = 4,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "City of Broken Dreams",
                        Description = "A dystopian thriller set in a future where society has crumbled, and a group of rebels must fight to reclaim their freedom.",
                        Price = 14.99,
                        MovieImageURL = "https://m.media-amazon.com/images/I/819gNL8D-RL._AC_UF1000,1000_QL80_.jpg",
                        StartDate = new DateTime(2025, 3, 1),
                        EndDate = new DateTime(2025, 3, 25),
                        Category = MovieCategory.Action,
                        CinemaId = 1,
                        ProducerId = 5
                    },
                    new Movie()
                    {
                        Title = "The Return of the King",
                        Description = "A fantasy adventure where an ancient prophecy unfolds and the chosen one must return to claim the throne.",
                        Price = 18.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BMTZkMjBjNWMtZGI5OC00MGU0LTk4ZTItODg2NWM3NTVmNWQ4XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                        StartDate = new DateTime(2025, 3, 10),
                        EndDate = new DateTime(2025, 3, 30),
                        Category = MovieCategory.Fantasy,
                        CinemaId = 5,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "Frozen Heart",
                        Description = "A chilling tale of survival in a frozen wasteland, where a group of explorers must endure the harshest conditions to find a way back home.",
                        Price = 13.00,
                        MovieImageURL = "https://res.cloudinary.com/teepublic/image/private/s--AUNd-vJU--/c_crop,x_10,y_10/c_fit,h_1109/c_crop,g_north_west,h_1260,w_1260,x_-117,y_-76/co_rgb:000000,e_colorize,u_Misc:One%20Pixel%20Gray/c_scale,g_north_west,h_1260,w_1260/fl_layer_apply,g_north_west,x_-117,y_-76/bo_0px_solid_white/t_Resized%20Artwork/c_fit,g_north_west,h_1054,w_1054/co_ffffff,e_outline:53/co_ffffff,e_outline:inner_fill:53/co_bbbbbb,e_outline:3:1000/c_mpad,g_center,h_1260,w_1260/b_rgb:eeeeee/t_watermark_lock/c_limit,f_auto,h_630,q_auto:good:420,w_630/v1665899822/production/designs/35712560_0.jpg",
                        StartDate = new DateTime(2025, 3, 15),
                        EndDate = new DateTime(2025, 4, 5),
                        Category = MovieCategory.Drama,
                        CinemaId = 1,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "Fate's Web",
                        Description = "A psychological thriller where an investigator must solve a string of mysterious disappearances that seem linked to a single person.",
                        Price = 14.99,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BMTM3ZWIxYzItYmYyNC00MzZiLTkzZWItOWFlZjVkMzg5ODk3XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                        StartDate = new DateTime(2025, 4, 1),
                        EndDate = new DateTime(2025, 4, 25),
                        Category = MovieCategory.Thriller,
                        CinemaId = 5,
                        ProducerId = 1
                    },
                    new Movie()
                    {
                        Title = "Dawn of Rebellion",
                        Description = "A historical drama about a group of rebels who lead a revolution against a tyrannical empire.",
                        Price = 17.00,
                        MovieImageURL = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1502138409i/32020194.jpg",
                        StartDate = new DateTime(2025, 4, 10),
                        EndDate = new DateTime(2025, 5, 1),
                        Category = MovieCategory.Historical,
                        CinemaId = 4,
                        ProducerId = 2
                    },
                    new Movie()
                    {
                        Title = "Into the Abyss",
                        Description = "A group of scientists discovers a portal to another world, but what they find there could change everything we know about reality.",
                        Price = 15.50,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BNTQyODM2MzMxMV5BMl5BanBnXkFtZTcwNDIzNjY5Ng@@._V1_.jpg",
                        StartDate = new DateTime(2025, 5, 1),
                        EndDate = new DateTime(2025, 5, 20),
                        Category = MovieCategory.ScienceFiction,
                        CinemaId = 1,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "Shattered Minds",
                        Description = "A gripping psychological drama about a man who loses his memory and tries to uncover the truth behind his past.",
                        Price = 12.50,
                        MovieImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmdl6mTaQxHWGtGiMKDHGKsQoeHVVWDHOzaQ&s",
                        StartDate = new DateTime(2025, 5, 10),
                        EndDate = new DateTime(2025, 5, 30),
                        Category = MovieCategory.Mystery,
                        CinemaId = 2,
                        ProducerId = 4
                    },
                    new Movie()
                    {
                        Title = "The Final Countdown",
                        Description = "A heart-pounding action thriller where a group of soldiers must stop a global catastrophe, but the clock is ticking.",
                        Price = 16.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BYjljZWJmOTktZGQyNi00NzFlLTk4ZmMtYzdjM2IxZDZiYjYyXkEyXkFqcGc@._V1_.jpg",
                        StartDate = new DateTime(2025, 5, 20),
                        EndDate = new DateTime(2025, 6, 10),
                        Category = MovieCategory.Action,
                        CinemaId = 5,
                        ProducerId = 5
                    },
                    new Movie()
                    {
                        Title = "The Last Whisper",
                        Description = "A romantic drama about two people from different worlds who find love despite the odds.",
                        Price = 13.50,
                        MovieImageURL = "https://m.media-amazon.com/images/I/61hmjqLY4iL._AC_UF350,350_QL50_.jpg",
                        StartDate = new DateTime(2025, 6, 1),
                        EndDate = new DateTime(2025, 6, 25),
                        Category = MovieCategory.Romance,
                        CinemaId = 1,
                        ProducerId = 3
                    },
                    new Movie()
                    {
                        Title = "The Chosen Path",
                        Description = "A spiritual journey where a young man searches for meaning in life, encountering unexpected challenges along the way.",
                        Price = 12.00,
                        MovieImageURL = "https://m.media-amazon.com/images/M/MV5BYzdhMzk4YjEtMDg1MS00NmU0LThiOTAtN2EwNzYwMWUwODQxXkEyXkFqcGc@._V1_.jpg",
                        StartDate = new DateTime(2025, 6, 5),
                        EndDate = new DateTime(2025, 6, 30),
                        Category = MovieCategory.Drama,
                        CinemaId = 3,
                        ProducerId = 2
                    }
                });

                context.SaveChanges();
            }

            // Actors & Movies
            if (!context.ActorMovies.Any())
            {
                var actorMoviesToAdd = new List<ActorMovie>();

                // "The Adventure Begins"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 1, ActorId = 1 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 1, ActorId = 2 }); 

                // "Whispers in the Dark"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 2, ActorId = 3 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 2, ActorId = 4 }); 

                // "Galactic Voyage"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 3, ActorId = 4 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 3, ActorId = 5 }); 

                // "Falling Leaves"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 4, ActorId = 4 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 4, ActorId = 5 }); 

                // "Beyond the Horizon"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 5, ActorId = 5 }); 

                // "The Phantom Rift"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 6, ActorId = 4 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 6, ActorId = 5 }); 

                // "Solar Flare"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 7, ActorId = 3 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 7, ActorId = 1 }); 

                // "Crimson Shadow"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 8, ActorId = 3 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 8, ActorId = 1 }); 

                // "Invisible Forces"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 9, ActorId = 5 }); 
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 9, ActorId = 2 }); 

                // "Whispers from the Past"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 10, ActorId = 3 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 10, ActorId = 4 });

                // "Time Traveler's Journey"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 11, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 11, ActorId = 4 });

                // "Echoes of Eternity"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 12, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 12, ActorId = 2 });

                // "Undercover Storm"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 13, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 13, ActorId = 4 });

                // "Rise of the Titans"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 14, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 14, ActorId = 2 });

                // "The Last Stand"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 15, ActorId = 3 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 15, ActorId = 1 });

                // "The Secret of the Labyrinth"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 16, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 16, ActorId = 2 });

                // "Shadows of the Lost City"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 17, ActorId = 3 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 17, ActorId = 4 });

                // "Wings of Freedom"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 18, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 18, ActorId = 4 });

                // "City of Broken Dreams"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 19, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 19, ActorId = 2 });

                // "The Return of the King"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 20, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 20, ActorId = 1 });

                // "Frozen Heart"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 21, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 21, ActorId = 4 });

                // "Fate's Web"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 22, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 22, ActorId = 1 });

                // "Dawn of Rebellion"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 23, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 23, ActorId = 2 });

                // "Into the Abyss"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 24, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 24, ActorId = 4 });

                // "Shattered Minds"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 25, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 25, ActorId = 4 });

                // "The Final Countdown"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 26, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 26, ActorId = 2 });

                // "The Last Whisper"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 27, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 27, ActorId = 4 });

                // "The Chosen Path"
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 28, ActorId = 5 });
                actorMoviesToAdd.Add(new ActorMovie { MovieId = 28, ActorId = 2 });


                context.ActorMovies.AddRange(actorMoviesToAdd);
                context.SaveChanges();
            }

        }
    }
}
