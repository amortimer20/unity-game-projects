# Game Design — Unity Reference Projects

Finished reference builds for **Fundamentals of Game Design**, one Unity project per
game. These are the instructor's copies: the course activities are cut from them, and
every figure and clip names a state in here.

**Unity 6.7, currently `6000.7.0b10`.** The pin is re-evaluated when 6.7 final ships,
before teaching starts in mid-January; after that it stays fixed for the 2026–27 run.
Editor screenshots are tied to it, so changing the version can make the course's figures
wrong.

Replaces the Godot-era `game-design-projects` repository, retired when the course moved
to Unity on 2026-11-25.

## Projects

| Folder | Game | Course activities |
|---|---|---|
| `junkyard/` | Physics demolition sandbox | 1.2–1.11 |
| `shooter/` | Vertical space shooter | 1.12–1.19 |
| `platformer/` | Run, jump, shoot | 2.1–2.16 |

All three are built and tagged for every activity.

## Tags are the point

**Every activity's end state is a git tag** — `junkyard/1-3`, `shooter/1-14`. GitHub
generates a downloadable zip per tag automatically, and since `Library/` and the other
regenerated folders are gitignored, each zip is exactly `Assets/`, `Packages/` and
`ProjectSettings/` — the same set a student zips and submits.

That gives two things at once:

- A student who breaks their project, or ends up at a different machine, downloads the
  previous activity's tag and keeps working.
- Every figure and clip has an exact, reproducible starting state.

A tag's name matches the activity whose work it contains. `junkyard/1-3` is the project
as it stands **after** Activity 1.3, which is also the starting state for Activity 1.4.

**A tag is only made after the step has been played and confirmed working in the
editor.**

## Conventions

These projects model the course's conventions, because students read them as worked
examples. Ease of use comes first; each rule is the simplest form of common Unity
practice.

1. **Folders by type** inside `Assets/`: `Scenes/`, `Scripts/`, `Prefabs/`, `Sprites/`,
   `Materials/` (physics materials), `Audio/`, and where a game needs them `Fonts/`,
   `Tiles/` (tile assets and palettes) and `Animations/` (clips and controllers).
2. **A script goes on the object it controls**, one script per job.
3. **Tunable numbers are `public` fields.**
4. **`GetComponent` once in `Start`**, stored in a field, for components on the same
   object; anything else is dragged into an Inspector slot. Never `GameObject.Find`.
5. **One `GameManager`**, reachable as `GameManager.instance`. Otherwise direct method
   calls and `OnCollisionEnter2D` / `OnTriggerEnter2D`; no custom events.
6. **Input polls `Keyboard.current` and `Mouse.current`** and nothing else from the
   Input System — no Input Actions asset, no `PlayerInput`.
7. **Movement:** Junkyard is moved by physics; the shooter by its transform, with a
   Kinematic `Rigidbody2D` so triggers fire; the platformer by `Rigidbody2D` velocity,
   never by moving a dynamic body's transform.
8. **`PascalCase` classes and methods, `camelCase` fields, Allman braces.**

## Assets

Everything committed here is **CC0**, because these projects are distributed to students
as zips and that is redistribution. Kenney packs carry their `license.txt` alongside the
art they came from. Nothing comes from the Asset Store or an AI generator.

**One exception, kept on purpose (2026-11-27):** `Assets/TextMesh Pro/` is Unity's own
TMP Essential Resources, which every project imports before its first text appears. It
bundles the LiberationSans font under the SIL Open Font License, with
`LiberationSans - OFL.txt` alongside. The OFL permits redistribution, and keeping the
import intact matches what students' own projects contain. The games' visible text uses
the Kenney fonts.

## Authoring with the Unity CLI

The projects are built by driving the editor with the Unity CLI, which needs its
**Pipeline package** (`com.unity.pipeline`) in the project. `unity projects create` adds
it automatically. It must never reach a commit, because every tag is a zip students
download, so:

- **`Packages/manifest.json` is committed without it.** After any package change, run
  `scripts/stage-manifest.sh <project>`: it stages the manifest minus the Pipeline line
  and marks the file skip-worktree so the local copy stays as the CLI needs it.
- **`Packages/packages-lock.json` is not committed.** Unity rebuilds it from the
  manifest on open, and the local one lists Pipeline.
- **A pre-commit hook refuses any staged manifest or lock that names it.** After a
  fresh clone, enable it once: `git config core.hooksPath .githooks`.

Agent scripts (`AgentScripts/`) and editor captures (`Screenshots/`) live inside each
project folder for the CLI's convenience and are gitignored.

**Keep the clone at a short path.** Windows' 260-character limit breaks Unity's package
import when the project sits deep in the file system.
