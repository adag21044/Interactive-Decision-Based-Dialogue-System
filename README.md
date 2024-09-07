# Unity Interactive Decision-Based Dialogue System

This Unity project implements a dialogue system using a decision tree structure. The system manages the flow of dialogues and handles player choices using a `DialogueManager`, `DialogueNode`, and various strategies for choice handling.

## Overview

- **DialogueManager**: Manages the dialogue flow, displays dialogue text, and handles player choices.
- **DialogueNode**: Represents a node in the dialogue tree, including dialogue text and possible choices.
- **DialogueTree**: Creates and holds the dialogue nodes to form a dialogue tree.
- **IChoiceStrategy**: Interface for strategies to handle dialogue choices.
- **ICommand**: Interface for command execution.
- **MakeChoiceCommand**: Command to execute a choice in the dialogue system.
- **SimpleChoiceStrategy**: Strategy for handling simple choice execution.

## Code Overview

- **DialogueManager.cs**: Handles the display and logic of the dialogue system.
- **DialogueNode.cs**: Defines each dialogue node and its possible choices.
- **DialogueTree.cs**: Manages the overall dialogue structure and starting node.
- **IChoiceStrategy.cs**: Defines the strategy interface for executing choices.
- **ICommand.cs**: Interface for command pattern implementation.
- **MakeChoiceCommand.cs**: Command implementation for making a choice.
- **SimpleChoiceStrategy.cs**: Basic strategy for executing choices.



## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

