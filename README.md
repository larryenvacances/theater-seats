# Getting Started

The project is seperated in two different folders, one for the frontend in react, one for the backend in C#.

# Inspiration

- The frontend project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).
- The backend project was forked from [dotnet-api-boilerplate](https://github.com/yanpitangui/dotnet-api-boilerplate).

# Docker

- The backend I forked from supports docker-compose, but I was not able to test it on my personnal machine because it doesn't support virtualization.
  You can try it and I'm 75% sure it works, but even though I tried real hard, I had limiting factors working against me.

# Prerequisites

- If docker-compose does not work, you will need, in order to run the backed in standalone:
  - [SQL Express](https://go.microsoft.com/fwlink/?linkid=866658)
  - [net core 5 sdk](https://dotnet.microsoft.com/download/dotnet/5.0)
  - [Node v14](https://nodejs.org/dist/v14.17.6/node-v14.17.6-x64.msi)

# Data seeding

- You will notice that some data is seeded on the bootstrap of the application. The movie "Silence of the Lambdas" is visible from DateTime.Now - 10 days until DateTime.Now + 10 days, to make testing easier.
- The swagger ui will allow you to insert some data to your liking. It is my "lazy" implementation of the admin page that lets users create movies, for example.

# Further reading

- Each part of the application (front+back) have their own readme
