# Windows RAT (Remote Administration Tool)

Educational tool for testing Windows security. !!! Currently in active development !!!.

> ⚠️ **DISCLAIMER**: For educational purposes only. Use only on systems you own.

## 🚀 Current Features

- **Interactive Shell** with command system
- **Machine Management** commands (list, info, rename, delete, ping)
- **Admin rights detection**
- **Menu system** with navigation

## 📋 Available Commands

### Basic
- `help` - Show help
- `menu` - Return to menu
- `clear` / `cls` - Clear screen
- `exit` / `quit` - Exit program

### Machine Commands
- `machine --list` / `-l` - List machines
- `machine --info <ids>` / `-i` - Show machine info
- `machine --rename <id> <name>` / `-rn` - Rename machine
- `machine --delete <id>` / `-d` - Delete machine (admin)
- `machine --ping <all|ids>` / `-p` - Ping machines

## 🛠️ Build & Run

```bash
# Build
dotnet build

# Run
dotnet run

# Build standalone .exe
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# 📁 Project Structure
```
RAT/
├── Program.cs        # Entry point
├── Shell/
│   └── Shell.cs      # Shell commands
├── Menu/
│   └── Menu.cs       # Menu system
└── Utils/
    └── UtilsCollection.cs
```

# ⏳ Coming Soon

- Camera access
- Screenshot capture
- File system operations
- Network utilities
- Config management

# 📝 Note

This is a work in progress. Features are being added regularly.