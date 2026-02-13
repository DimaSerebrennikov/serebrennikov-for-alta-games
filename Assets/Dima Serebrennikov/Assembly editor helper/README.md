# 🤖 Assembly editor helper

Technology that allows you to manage modules.

### Similar to

- Unity's built-in Assembly Definition button turns a folder into a module.

- Unity Package collects all dependencies into a single package.

### Prospect

The Main Menu button creates a separate window for working with all modules in the project.

This window:

- Displays all modules.

- Allows you to quickly open a module's design without having to navigate to a folder.

- Allows you to create new modules for the project using a predefined or specified path.

- Allows you to provide links between modules.

Covered with unit tests.

### Features

Allows you to create modules using the Create Menu button: "Serebrennikov/Module" in the selected folder.

The created module contains:

- A design folder with an MD file inside with the module's name.

- An assembly named according to assembly name conventions.

- A C# file to make it easier to start filling the module.

Before creating a module, you can write its name and specify a word below it, which will act as a name prefix and will be preserved between different calls.