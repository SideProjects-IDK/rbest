# rbest CLI Tool

Welcome to the **rbest** CLI tool! This software, currently at version `0.0.1`, is designed to manage and run projects in a structured manner. Below you'll find installation steps, basic usage instructions, and detailed explanations for each command.

---

## Installation

To use the `rbest` CLI, make sure it is installed and properly configured in your environment. For specific setup instructions, refer to your development environment's guidelines.

---

## Basic Usage

Run the following command to check if `rbest` is set up correctly:

<code>
rbest --version
</code>

This should output the current version of `rbest` and confirm it's working.

To start using `rbest`, simply run:

<code>
rbest &lt;command&gt; [options]
</code>

---

## Commands

Below is a list of available commands for `rbest`, along with descriptions and usage examples.

### `help`

Displays a help message with a list of commands and descriptions.

**Usage:**

<code>
rbest help
</code>

**Output:**

<code>
help              : For this help message
new $name         : To create a new roobi project.
                   (req: $project_name , $project_type)
                   (type: `help new` for more info)
run               : Runs current project.
rm                : Removes current project.
                   (req: ?$project_dir)
                   (needs to be in the same dir as `rbest.config.json`)
                   (type: `rm $project_dir` to delete a project dir)
</code>

### `new`

Creates a new project in the current directory.

**Usage:**

<code>
rbest new &lt;project_name&gt; &lt;project_type&gt;
</code>

If <code>&lt;project_name&gt;</code> is not provided, you'll be prompted to enter one manually.

**Example:**

<code>
rbest new MyProject 
</code>

### `run`

Runs the current project. Ensure you're in the correct project directory for this command to work.

**Usage:**

<code>
rbest run
</code>

### `rm`

Removes an existing project directory. This command expects to find a configuration file named `rbest.config.json` in the same directory.

**Usage:**

<code>
rbest rm &lt;project_dir&gt;
</code>

If <code>&lt;project_dir&gt;</code> is not provided, the command will attempt to read from `rbest.config.json`.

**Example:**

<code>
rbest rm MyProjectDir
</code>

---

## Error Handling

If a required file is missing, `rbest` will output an error message like this:

<code>
file `&lt;filename&gt;` not found!
</code>

If you enter an unrecognized command, `rbest` will display the following message:

<code>
no such command `&lt;command&gt;`, try typing `help`
</code>

---

## Example Usage

Here's an example workflow using the `rbest` CLI:

1. **Create a new project:**
   <code>
   rbest new MyCoolProject WebApp
   </code>

2. **Run the project:**
   <code>
   rbest run
   </code>

3. **Remove the project:**
   <code>
   rbest rm MyCoolProject
   </code>

---

## License

This software is licensed under the `Yuri-Is-On-Rage-Mode` License (2024).
