# Inspiration

- The backend project was forked from [dotnet-api-boilerplate](https://github.com/yanpitangui/dotnet-api-boilerplate).

# Note

- The tests that were added to the solution are just there to demonstrate the kind of tests I would write for a solution of this type. I would achieve a better coverage if it was production

# Docker

- The backend I forked from supports docker-compose, but I was not able to test it on my personnal machine because it doesn't support virtualization.
  You can try it and I'm 75% sure it works, but even though I tried real hard, I had limiting factors working against me.

# Prerequisites

- If docker-compose does not work, you will need, in order to run the backed in standalone:
  - [SQL Express](https://go.microsoft.com/fwlink/?linkid=866658), but only if you want to run the application on an actual database. If you want, you can also run the db in memory by commenting line 19 of DatabaseExtension and uncommenting line 20.
  - [net core 5 sdk](https://dotnet.microsoft.com/download/dotnet/5.0)
  - [Node v14](https://nodejs.org/dist/v14.17.6/node-v14.17.6-x64.msi)

# Data seeding

- You will notice that some data is seeded on the bootstrap of the application. The movie "Silence of the Lambdas" is visible from DateTime.Now - 10 days until DateTime.Now + 10 days, to make testing easier.
- The swagger ui will allow you to insert some data to your liking. It is my "lazy" implementation of the admin page that lets users create movies, for example.
