# CLAUDE.md

Project instructions for Claude Code working in this repository. Codex reads
the equivalent `AGENTS.md` in this same directory — keep the two in sync.

**Read [`README.md`](README.md) first.** It documents the per-game project
layout, the tag-per-activity convention, and the conventions these projects
model for students.

## What matters here

- **Unity is pinned to `6000.7.0b10`, deliberately**, until 6.7 final ships
  and the pin is re-evaluated; after that it stays fixed for 2026–27. Editor
  screenshots across `skynest-nexus` are tied to it. Don't open a project in
  a different editor version — Unity silently upgrades the project on open.
- **Every activity's end state is a git tag** (`junkyard/1-3`,
  `shooter/1-14`). Students download these as GitHub zips to recover a
  broken project, so a tag is made only after the step has been played and
  confirmed working in the editor.
- **The Unity CLI's Pipeline package (`com.unity.pipeline`) must never be in
  a commit.** It is for authoring only, and `unity projects create` adds it
  to every new project automatically. Before committing, check that
  `Packages/manifest.json` does not list it — every tagged commit is a zip a
  student downloads.
- **No Asset Store items, no AI-generated assets.** Everything committed is
  CC0, with its license file alongside.
- **`Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/` and build output
  are gitignored on purpose**, so tag zips stay small, clean projects.

## Relationship to the site repo

This repo is nested inside `skynest-nexus` as `unity-game-projects/` and is
gitignored there. Web builds of these projects are generated into the site's
`public/games/` and never committed to either repo.
