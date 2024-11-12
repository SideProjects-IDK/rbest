dir tree:


```
/project
├── rbest.config.json
├── rbest.lang.config.json
├── rbest.lang.require.paths.json
├── rbest.package.json
├── rbest.vin.config.json
├── rbest.system.config.json
├── README.txt
├── /libs
│   └── some basic libs
└── /main
    ├── main.rb
    └── helper.rb
```

### `rbest.config.json`
```json
{
    "vin-compatable":"true",
    "nu-compatable":"true",
    "vin":{
        "admin-user":"$admin-user-name"
    }
}
```

### `rbest.lang.config.json`
```json
{
    "lang":"roobi",
    "roobi":{
        "version":"$current-ruby-version",
        "platform":"$current-platform-weather-windows-linux-or-macos"
    },
    "require":{
        "files":{
            "main":"$pwd/rbest.lang.require.paths.json"
        }
    }
}
```

### `rbest.lang.require.paths.json`
```json
[
    {
        "alias":"@main",
        "path":"$pwd/main"
    },
    {
        "alias":"@libs",
        "path":"$pwd/libs"
    }
]
```

### `rbest.package.json`
```json
{
    "project-name":"$your-project-name",
    "project-location":"$pwd",
    "project-conf":{
        "vin":"$pwd/rbest.vin.config.json",
        "sys":"$pwd/rbest.system.config.json"
    },
    "project-main":{
        "scripts":{
            "main":"$pwd/main/main.rb"
        },
        "dependencies":{
            "local":{
                "helper.rb":"$pwd/main/helper.rb"
            },
            "jems":{}
        }
    },
    "project-author":{
        "name":"$author-name",
        "github":"$author-github-name-link"
    },
    "project-publish":{
        "license":"MIT",
        "copyright":"$suthor-name"
    }
}
```

### `rbest.vin.config.json`
```json
{
    "th7d6438-r8yh342-r8yd-rd3428":"28347f-t8y47-yr8d-t8y5f73",
    generate random lines like that 15 times,
}
```

### `rbest.system.config.json`
```json
{
    "os":{
        "name":"$current-os-name",
        "version":"$current-os-version"
    }
}
```