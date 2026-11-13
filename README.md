Municipal Services Application - Project Completion

 How to Compile and Run the Application
1. Ensure you have Visual Studio 2022 (or later) installed with the .NET Desktop Development workload.
2. Open the `MunicipalServiceApp.sln` file.
3. Press `F5` or click the Start button at the top of Visual Studio to compile and run the application.
4.  How to Use:
   Report Issues:Click this button to log a new municipal issue (implemented in Part 1).
   Events & Announcements:Click this to view upcoming events, search by date/category, and view personalized recommendations (implemented in Part 2).
   Service Request Status: Click this to view the Part 3 dashboard. You can search for requests using their ID (e.g., `SR-0003`) and view urgent requests ordered by priority. 


 Implementation Report: Data Structures

Throughout the development of this application, various advanced data structures were implemented to ensure high performance and efficient data retrieval.

 Events and Announcements
    Sorted Dictionaries: Used to automatically store events in chronological order based on their dates. This makes displaying upcoming events highly efficient (O(log n) lookups).
    Queues & Stacks: A `Queue` was used to manage incoming announcements (FIFO), and a `Stack` was used to track the user's recently viewed events (LIFO).
    Sets (HashSet): Used to instantly identify unique categories and unique event dates, preventing duplicates in the UI dropdowns.
    Recommendation Algorithm: A weighted scoring algorithm tracks user search patterns and viewed events to suggest related events based on category affinity and date proximity.

 Part 3: Service Request Status
    Binary Search Tree (BST): Implemented for the "Track Request" feature. When a user enters a reference number (e.g., `SR-0002`), the BST halves the search space at every step, providing rapid O(log n) lookups.
    AVL Tree:Used in the "Dashboard" tab. Because standard BSTs can become unbalanced (degenerating into a linked list), the AVL tree uses Left/Right rotations to self-balance, guaranteeing O(log n) traversal and sorted display by ID.
    Red-Black Tree:Utilised via C#'s built-in `SortedDictionary`. It ensures balanced insertions and strict ordering of requests by reference number.
    Min-Heap (Priority Queue): Used to manage the urgency of requests. By keeping the highest priority request (e.g., a sewage leak) at the root, the municipality can extract the most critical tasks in O(1) time.
    Graph & Minimum Spanning Tree (MST): The municipal escalation workflow (Citizen -> Call Center -> Councillor) is modeled as a weighted Graph. Breadth-First Search (BFS) calculates the shortest escalation path, while Kruskal's MST algorithm maps the most time-efficient connection between all departments without creating cycles.



 3. Project Completion Report

Challenges Faced During Task 3:
The primary challenge in Task 3 was implementing the complex self-balancing logic for the AVL tree and ensuring smooth integration with the existing Windows Forms. Additionally, resolving compiler errors related to Nullable Reference Types (`?`) required a deep understanding of the `.csproj` configuration. Linking the visual designer buttons to the backend logic in `MainForm.cs` also required careful event-handling and debugging to ensure the application navigated seamlessly without crashing.

Key Learnings & Insights:
This project bridged the gap between theoretical computer science and practical software engineering. I gained significant insights into how algorithmic complexity impacts real-world applications. For example, writing a custom Min-Heap for priority dispatch and a Graph for escalation proved how data structures solve actual municipal logistics problems. I also vastly improved my debugging skills in Visual Studio and learned to design modular, maintainable UI code.


4. Technology Recommendations

To further enhance the functionality and performance of the Municipal Services Application in a real-world scenario, I recommend the following technologies:

1.  Entity Framework Core & SQL Server:
        Justification: Currently, the application stores data in memory (which is lost when the app closes). Integrating a SQL relational database would provide data persistence, allowing requests and events to be saved permanently. Entity Framework would map our C# objects directly to database tables.
2.   ASP.NET Core Web API & Mobile Frontend:
        Justification: A desktop application limits accessibility. Creating a RESTful Web API backend would allow citizens to submit and track requests via a mobile app (using Xamarin/MAUI) or a web browser, drastically increasing the platform's reach in South Africa.
3.   Azure Cloud Hosting & SignalR (WebSockets):
        Justification: Hosting the backend on Microsoft Azure would ensure 99.9% uptime. By using SignalR, the application could send real-time push notifications to a user's phone the moment their service request status changes from "In Progress" to "Resolved".
