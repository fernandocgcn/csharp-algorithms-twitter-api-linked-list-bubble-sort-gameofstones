# csharp-algorithms-twitter-api-linked-list-bubble-sort-gameofstones
(C#) A Bubble Sort Implementation; A Linked List Implementation; A Game of Stones Implementation; And Consuming Twitter API to search the last 10 Tweets containing a Input Word

### Backend

* src/Challenges/WonderList.cs - **Linked List** and **Bubble Sort** Implementations

* src/Challenges/Solution.cs - **GameOfStones** Algorithm Solution Implementation (https://www.hackerrank.com/challenges/game-of-stones-1)

* src/TwitterApi - Using the twitter API, a project that given a word as an input, outputs the last 10 tweets containing that word
    1. src/TwitterApi/Models - Tweet Entity
    2. src/TwitterApi/Factories - **Factory Pattern** to create Tweets objects
    3. src/TwitterApi/Services - Microservices that use **Inversion of Control Principle** through .NET Core **Dependency Injection Pattern**
    4. src/TwitterApi/Controllers - Restful API to access my microservices (available to outside users - Ex.: https://localhost:44389/searchtweets?searchWord=beatles)
    5. src/TwitterApi/Caching - **Caching Strategy** to improve performance (one minute for my example), optional and easy to disable it in the Startup class
![](/misc/tweets-screenshot.png "Retrieved Tweets Screenshot")

- Suppose you're working with 3 people on a project. What would be **the** ideal software development process?
    - As not given too many details in this question, only that we are a very small team, I would choose an agile development methodology, such as **Scrum**, based on incremental feature development and continuous integration, the best for small teams and fast-moving projects because improves flexibility and adaptability. It would also include **Kanban** in the process, as the team would feel they have more control over the process, allowing a quick decision-making.

- How do you think an entity relationship diagram for _Instagram_ would be like?
![](/misc/InstagramERD.png "It's an initial scratch!")

- Now that you have imagined the ER diagram, **how** would you build _Instagram_ from scratch?
![](/misc/InstagramCD.png)
    - In terms of architecture, as shown in the component diagram above, I would create a layer to access database (relational or not), a domain layer where the class model and microservices would be with the business logic and, last but not least, a presentation layer that can be a SPA (single page application).
