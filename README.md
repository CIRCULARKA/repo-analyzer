# repo-analyzer -- CI tool for repository rules enforcement

## Overview

### Idea

The idea behind the tool is to make CI more convenient to configure for many
repositories in organization.

The tool will be accepting some configuration files that must describe some rules
for the repository being checked
and automatically will check if rules aren't violated. Examples of such rules are:

- Repository should have only one `.editorconfig` in specific place and this file
must be equal to template
that accepted company-wide
- All .NET projects should reference `StyleCop.Analyzer` package (to enforce style
guides that are described in `.editorconfig`, for example)
- All source code must be in `src` folder relative to repository root
- Other restrictive rules that will enforce cross-repository consistency

I believe that such a tool will really improve repositories consistency in organization
without much of agreements between developers:
owners just need to add the tool to the global CI process to make all repositories
consistent between each other as much as it's possible.

I want this tool to be integrated in CI as simple as possible:

- Without need to setup environment (self contained executable)
- Cross-platform support

### Usage

I see the usage of the tool in CI in this way:

```bash
wget -O rz https://repo-analyzer.com/repo-analyzer-linux-latest.sh
chmod +x rz
./rz --ruleset /volume/dotnet-rulesets.json .
```

With output similar to:

```txt
34 rules being checked:
- <rule-name-1>: OK
- <rule-name-2>: OK
- ...
- <rule-name-10>: Not all source code is in `src` folder

Exit Code 1
```

## Contribution

To be done.
