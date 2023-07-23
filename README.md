# Chinook

This application is unfinished. Please complete below tasks. Spend max 2 hours.
We would like to have a short written explanation of the changes you made.

1. Move data retrieval methods to separate class / classes (use dependency injection)
2. Favorite / unfavorite tracks. An automatic playlist should be created named "My favorite tracks"
3. The user's playlists should be listed in the left navbar. If a playlist is added (or modified), this should reflect in the left navbar (NavMenu.razor). Preferrably, the left menu should be refreshed without a full page reload.
4. Add tracks to a playlist (existing or new one). The dialog is already created but not yet finished.
5. Search for artist name

When creating a user account, you will see this:
"This app does not currently have a real email sender registered, see these docs for how to configure a real email sender. Normally this would be emailed: Click here to confirm your account."
After you click 'Click here to confirm your account' you should be able to login.

Please put the code in Github. Please put the original code (our code) in the master branch, put your code in a separate branch, and make a pull request to the master branch.


#Completion Note - Nishanthan
1. Not very experienced in Blazor, but tried my best to learn something and did the project in the standard structure.
2. Completed all 5 tasks except the page refresh part on the left NavBar menu on task 3.
3. Followed the standard Blazor structure without going for Jquery or JavaScript based concept.
4. Used Dipendency Injection as one of the design patterns.
5. Separation of Concern, Single responsibility, Inversion of Control are used when writing the backend code.
6. Implement this project with 3 tire architecture but the project does not have any business logic because only read/write operations are there in the test, and did not use it. Added the Business/Service layer to build the business logic of the architecture.
7. The original code is pushed to the main branch before doing the tasks. Tasks are done on develop branch and merge to the main branch after the completion.