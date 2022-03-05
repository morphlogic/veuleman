using VeulemanTrainingPlatform.Models;

namespace VeulemanTrainingPlatform.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Courses.Any())
            {
                return;
            }

            var courses = new Course[]
            {
                new Course
                {
                    Name = "Reno SD Readiness Training",
                    Description = "Want to be a member of the Reno Sheriff's department? You need this information. *bang* You're dead!",
                    Chapters = new Chapter[]
                    {
                        new Chapter
                        {
                            Title = "Reno SD Public Relations",
                            Order = 1,
                            Description = "Learn public relations from the Reno Sheriff's department! \n\r Proin rutrum magna sit amet gravida efficitur. Donec aliquet ex id ex blandit elementum. Curabitur eleifend nisl sit amet nunc tristique, et consequat libero volutpat. Donec eros ipsum, malesuada at elit at, scelerisque congue neque. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed volutpat luctus bibendum. Curabitur scelerisque scelerisque varius. Etiam nec fermentum arcu, ac suscipit felis.",
                            ContentPages = new[]
                            {
                                new ContentPage
                                {
                                    Title = "Lesson 1 Reno SD PR",
                                    Order = 1,
                                    Description = "This is where you start to learn about PR from the Reno SD PR",
                                    Content = "Praesent nec lorem eu dui maximus vestibulum ac a nulla. Morbi ultricies in nisi vitae eleifend. Sed lorem orci, dictum ac odio a, gravida pulvinar velit. Nulla vitae velit sed purus dictum aliquet ac ut arcu. Suspendisse sit amet eros at ipsum sollicitudin tristique. Mauris convallis eget tortor non vehicula. Nulla malesuada vulputate fringilla. Praesent quis velit condimentum massa mattis molestie non vel felis. Nulla fermentum ante ac auctor blandit. Cras quam nisl, ullamcorper consequat semper a, maximus sit amet enim. Mauris eget mauris ligula. Duis orci eros, tempus a enim id, volutpat bibendum ligula. Vivamus aliquet mauris lobortis orci posuere eleifend."
                                },
                                new ContentPage
                                {
                                    Title = "Lesson 2 Reno SD PR",
                                    Order = 2,
                                    Description = "This is where you continue to learn about PR from the Reno SD PR",
                                    Content = "Fusce pellentesque vulputate laoreet. Aenean laoreet sem at sem consequat venenatis. Cras non varius tortor, at vulputate leo. Nulla facilisi. Sed elementum est vitae feugiat sodales. Etiam lacinia nisi odio, eu lacinia mi sagittis eu. Fusce viverra hendrerit lectus nec accumsan. In sagittis purus justo, non viverra lorem euismod non."
                                },
                                new ContentPage
                                {
                                    Title = "Lesson 3 Reno SD PR",
                                    Order = 3,
                                    Description = "This is where you finish learning about PR from the Reno SD PR",
                                    Content = "Aenean euismod turpis a ipsum ultrices rhoncus. Nam elementum imperdiet massa, eget lacinia libero accumsan eu. Proin dui nunc, ultricies non placerat eget, euismod molestie nulla. Nullam ac volutpat dui, a malesuada risus. Quisque at efficitur mi. Mauris vel rutrum tellus. Vivamus vitae eros accumsan, tempus nibh sit amet, faucibus erat. Nam maximus vitae neque nec elementum. Duis nisl velit, feugiat sit amet pulvinar vel, tristique ut nisi. Nam dapibus luctus risus, at hendrerit sapien auctor id."
                                }
                            },
                            QuizPage = new QuizPage
                            {
                                Title = "Quiz for Reno SD Public Relations !!!11one",
                                Description = "Here, we'll test your competence as a candidate for PR certification by Reno SD",
                                Content = "Integer mattis pellentesque enim sollicitudin ornare. Nam dictum urna eu massa tincidunt, a imperdiet elit sodales. Praesent odio odio, efficitur ut nibh at, tristique congue lacus. Nullam a nisl vel risus luctus imperdiet in nec libero. In hac habitasse platea dictumst. Morbi eu nisl ante. Integer consectetur dignissim dapibus. Integer et condimentum arcu. Morbi purus velit, condimentum at nisi at, vestibulum cursus leo. Donec accumsan tellus vitae sem rhoncus semper. Pellentesque efficitur orci eget velit consequat sodales."
                            }
                        },
                        new Chapter
                        {
                            Title = "How to Avoid Being Sued",
                            Order = 2,
                            Description = "Learn how not to be sued while operating in the Reno SD! \n\r Praesent condimentum tellus id ipsum interdum pellentesque. Nunc vel velit sed nisl molestie tempor quis pharetra neque. Duis quam sem, ultrices et pharetra eget, iaculis ac ex. Pellentesque condimentum nisi interdum nisl convallis faucibus. Mauris sed quam eget lectus dignissim sodales vitae ac massa. Sed scelerisque feugiat velit, pulvinar consectetur purus sollicitudin nec. Sed suscipit est scelerisque cursus ultrices. Pellentesque laoreet ac mi nec fringilla. Nulla in tempor nulla, at porttitor metus. Proin vel ex et nibh sagittis imperdiet. Donec congue dui vel luctus pulvinar. Sed nibh nisi, congue in luctus volutpat, consequat vitae elit. Praesent sed mi ipsum. Aenean viverra non elit a molestie.",
                            ContentPages = new []
                            {
                                new ContentPage
                                {
                                    Title = "Lesson 1 Not Getting Sued",
                                    Order = 1,
                                    Description = "This is where you start to learn about not getting sued from the Reno SD PR",
                                    Content = "Praesent nec lorem eu dui maximus vestibulum ac a nulla. Morbi ultricies in nisi vitae eleifend. Sed lorem orci, dictum ac odio a, gravida pulvinar velit. Nulla vitae velit sed purus dictum aliquet ac ut arcu. Suspendisse sit amet eros at ipsum sollicitudin tristique. Mauris convallis eget tortor non vehicula. Nulla malesuada vulputate fringilla. Praesent quis velit condimentum massa mattis molestie non vel felis. Nulla fermentum ante ac auctor blandit. Cras quam nisl, ullamcorper consequat semper a, maximus sit amet enim. Mauris eget mauris ligula. Duis orci eros, tempus a enim id, volutpat bibendum ligula. Vivamus aliquet mauris lobortis orci posuere eleifend."
                                },
                                new ContentPage
                                {
                                    Title = "Lesson 2 Not Getting Sued",
                                    Order = 2,
                                    Description = "This is where you continue to learn about not getting sued from the Reno SD PR",
                                    Content = "Fusce pellentesque vulputate laoreet. Aenean laoreet sem at sem consequat venenatis. Cras non varius tortor, at vulputate leo. Nulla facilisi. Sed elementum est vitae feugiat sodales. Etiam lacinia nisi odio, eu lacinia mi sagittis eu. Fusce viverra hendrerit lectus nec accumsan. In sagittis purus justo, non viverra lorem euismod non."
                                },
                                new ContentPage
                                {
                                    Title = "Lesson 3 Not Getting Sued",
                                    Order = 3,
                                    Description = "This is where you finish learning about not getting sued from the Reno SD PR",
                                    Content = "Aenean euismod turpis a ipsum ultrices rhoncus. Nam elementum imperdiet massa, eget lacinia libero accumsan eu. Proin dui nunc, ultricies non placerat eget, euismod molestie nulla. Nullam ac volutpat dui, a malesuada risus. Quisque at efficitur mi. Mauris vel rutrum tellus. Vivamus vitae eros accumsan, tempus nibh sit amet, faucibus erat. Nam maximus vitae neque nec elementum. Duis nisl velit, feugiat sit amet pulvinar vel, tristique ut nisi. Nam dapibus luctus risus, at hendrerit sapien auctor id."
                                }
                            },
                            QuizPage = new QuizPage
                            {
                                Title = "Quiz for Reno SD Not Getting Sued !!!11one",
                                Description = "Here, we'll test your competence as a candidate for Not Getting Sued certification by Reno SD",
                                Content = "Integer mattis pellentesque enim sollicitudin ornare. Nam dictum urna eu massa tincidunt, a imperdiet elit sodales. Praesent odio odio, efficitur ut nibh at, tristique congue lacus. Nullam a nisl vel risus luctus imperdiet in nec libero. In hac habitasse platea dictumst. Morbi eu nisl ante. Integer consectetur dignissim dapibus. Integer et condimentum arcu. Morbi purus velit, condimentum at nisi at, vestibulum cursus leo. Donec accumsan tellus vitae sem rhoncus semper. Pellentesque efficitur orci eget velit consequat sodales."
                            }
                        }
                    },
                    FinalPage = new FinalPage
                    {
                        Title = "This is your final exam! Don't screw the pooch, gumshoe!",
                        Description = "Any questions? No? Hope not \n\r You should know everything by now. \n\r Don't screw the pooch!",
                        Content = "Aliquam sed mauris et mi vehicula egestas. Interdum et malesuada fames ac ante ipsum primis in faucibus. Praesent dignissim turpis et dui efficitur, sed cursus enim vulputate. Suspendisse rutrum augue eu commodo tempor. Proin eu ornare enim. In malesuada viverra ex, ac dictum justo suscipit quis. Praesent et metus in nunc malesuada commodo et eu dolor. Mauris ante lectus, ullamcorper id commodo id, egestas vel nulla. Sed lacinia, nunc nec sodales volutpat, odio nibh aliquet mi, in maximus est orci in urna. Vivamus quam massa, laoreet in feugiat sed, porta a massa. Donec non nulla quis eros vulputate porta vel ornare nunc. Curabitur quis nisl non risus feugiat gravida. Cras mollis massa eu massa gravida, sit amet auctor tellus fringilla. Praesent congue mi quis nibh pretium, non fringilla massa sollicitudin. Aenean nec fermentum dolor, et ullamcorper odio. Nullam viverra quis urna a vehicula."
                    }
                }
            };

            context.Courses.AddRange(courses);

            context.SaveChanges();
        } 
    }
}
