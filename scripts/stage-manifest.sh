#!/bin/sh
# Stage <project>/Packages/manifest.json without the Unity CLI's Pipeline package,
# leaving the working copy (which the CLI needs) untouched, then hide the local
# difference from `git status`.
#   scripts/stage-manifest.sh junkyard
set -e
f="$1/Packages/manifest.json"
git update-index --no-skip-worktree "$f" 2>/dev/null || true
clean=$(grep -v '"com\.unity\.pipeline"' "$f" | sed -z 's/,\n  }/\n  }/' | git hash-object -w --stdin)
git update-index --add --cacheinfo 100644,"$clean","$f"
git update-index --skip-worktree "$f"
echo "staged $f without com.unity.pipeline"
