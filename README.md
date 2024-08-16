# PhoenixDown - Pinball Ascension

## General Guidelines:
  - Follow the principle of "readability counts." Write code that is clear and easy to understand.
  - Use meaningful names for variables, functions, classes, and other identifiers.
  - Keep code files concise and focused on a single responsibility, particularly when dealing with individual board components.
  - Comment your code when necessary to explain complex algorithms or tricky parts.

## Formatting:
  - Follow a consistent indentation style - 2 spaces.
  - Use descriptive and consistent naming conventions for variables, functions, and classes - camelCase.
  - Maintain consistent code formatting throughout the project. I'll look to see if we need something like prettier as we move forward but for the time being we won't have it (Kainoa).
  - Keep lines of code within a reasonable length (typically 80-120 characters) to improve readability.

## Documentation:
- Provide clear and concise comments within the code to explain the purpose of complex logic or unusual implementations.
- Document any assumptions or constraints that affect the behavior of the code.

## Version Control:
  - Branch from main when working on anything and open a PR into main when you're ready to merge. Ensure that your branch is up to date to avoid any potential merge conflicts.
  - Seek code review from the team before merge. We can't enforce this, nor merging straight to main without paying for a better GitHub account which I'm not interested in, so it's up to us to enforce this.

Follow these steps if you're unsure of how to handle version control within this respository (steps below are using any CLI tool of your choice):

1. If you don't have the repository, clone it to your local directory - `git clone https://github.com/DaftlyGrins/PhoenixDown.git`
2. Ensure you have the latest changes from main - `git pull origin main` (Note: If you have working changes on your local branch, you may have to handle merge conflicts when pulling in remote changes)
3. Once your branch is up to date with main, create a new branch from it: `git checkout -b <your-branch-name>
4. Stage your changes onto your new branch - `git add .`
5. Commit your changes - `git commit -m "<your-commit-message>"
6. Push your changes to the remote branch - "git push origin <your-branch-name>
7. Create a PR from your remote branch by either going to the repository and doing it visually through there, or in your terminal follow the external link that is created
8. Post in Discord for review of work

## Code Reviews:
  - Reviewers should ensure adherence to coding conventions, check for potential bugs, and verify that the code meets the project requirements.
  - Review should require at least one team member. If the work is complex, reach out to a team member to test before merging.
  - PRs should not be merged until all review comments are addressed and the changes are approved by at least one reviewer.
  - Encourage discussions during code reviews to share knowledge and improve the overall quality of the codebase.

## Performance:
  - Write efficient code and avoid unnecessary computations or resource-intensive operations. Our lengthy board design may need some considerations regarding performance due to the number of components we will have in each scene.

## Dependencies:
  - Avoid introducing unnecessary dependencies to keep the project lean and maintainable.
  - Regularly update dependencies to the latest stable versions to benefit from bug fixes and new features.
  - Reach out to the team regarding any external assets you are interested in introducing so we may discuss feasibility.

## Collaboration:
  - Foster a collaborative and inclusive environment where team members feel comfortable sharing ideas and providing feedback.
  - Encourage code reviews as a learning opportunity for both reviewers and authors.
  - Track all tasks you are working on within our [project management document](https://docs.google.com/spreadsheets/d/1S1k8c8X1QR-jsnY4qDF2xcZmKRZxYNAdwji6SujcBws/edit?usp=sharing).

## Inputs
  - Inputs should be added for components through InputManager for now (Edit > Project Settings > Input Manager).