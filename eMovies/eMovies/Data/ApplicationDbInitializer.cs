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


            //Movies
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                {
                    new Movie()
                    {
                        Title = "The Adventure Begins",
                        Description = "A group of unlikely heroes set off on a thrilling journey to save the world. Packed with action, suspense, and heartwarming moments.",
                        Price = 12.99,
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
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
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
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
                        MovieImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
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
                    }
                });
                context.SaveChanges();
            }


            //Actors & Movies
            if (!context.ActorMovies.Any())
            {
                context.ActorMovies.AddRange(new List<ActorMovie>()
                {
                    new ActorMovie()
                    {
                        MovieId = 1, 
                        ActorId = 1  
                    },
                    new ActorMovie()
                    {
                        MovieId = 1, 
                        ActorId = 2  
                    },
                    new ActorMovie()
                    {
                        MovieId = 2, 
                        ActorId = 3  
                    },
                    new ActorMovie()
                    {
                        MovieId = 2, 
                        ActorId = 4  
                    },
                    new ActorMovie()
                    {
                        MovieId = 3, 
                        ActorId = 4  
                    },
                    new ActorMovie()
                    {
                        MovieId = 3, 
                        ActorId = 5  
                    },
                    new ActorMovie()
                    {
                        MovieId = 4, 
                        ActorId = 4  
                    },
                    new ActorMovie()
                    {
                        MovieId = 4, 
                        ActorId = 5 
                    },
                    new ActorMovie()
                    {
                        MovieId = 5,
                        ActorId = 5
                    }
                });
                context.SaveChanges();
            }

        }
    }
}
