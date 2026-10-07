# Initial decisions

## D-001: Portfolio first

The first release is a small, public, professionally useful portfolio CV. Repository collection, LLM integration, metrics, advanced graphs, terminal emulation, carrier inspection, and a full authoring UI are deferred.

## D-002: Story first, evidence available

Overview content tells the human and professional story. Detail adds engineering context. Evidence supports verification. Evidence must not dominate the homepage or be required to understand a project.

## D-003: Composable content blocks

Use typed blocks for prose, quotations, commentary, code, terminal excerpts, images, links, evidence, callouts, and related content. Meaning belongs in data; screen and print presentation belongs in components.

## D-004: Keep the existing portfolio core

Use .NET 10 Blazor WebAssembly and GitHub Pages. Do not replace the public runtime with a repository profiler, collector, Python site, or LLM service.

## D-005: Keep dynamic data under src

Author source under `src/content/` and emit runtime data under `src/Ulfbou.Site/wwwroot/data/generated/`. Generated JSON is never hand-edited.

## D-006: Human authority

Ulf remains final state manager and publishing authority. Repository evidence and LLM suggestions are candidate inputs, not self-authorizing facts.

## D-007: Deterministic before probabilistic

Collection and validation are deterministic. LLM curation is optional, bounded, provenance-preserving, and review-gated.

## D-008: Tools emerge from demonstrated need

A collector starts with the smallest repository facts needed by real portfolio pages. Authoring tools are added only after the manual review workflow exposes repeated friction.

## D-009: Semantic non-regression

Preserve accepted facts, qualifications, authority, provenance, navigation, and behavior. Reorganization is allowed; unsupported strengthening, silent loss, or automatic publication is not.
