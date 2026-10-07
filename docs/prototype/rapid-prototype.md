# Rapid prototype plan

## Objective

Produce the smallest credible vertical slice that can be shared as a portfolio CV and extended without redesign. It must prove structured content, editorial project composition, responsive rendering, direct routes, and print behavior.

## Prototype scope

The prototype contains:

- homepage;
- canonical CV;
- portfolio index;
- two polished project case studies;
- profile, KTH experience, Stockholm University studies, competence, contact, and links;
- prose, code, terminal, commentary, links, image, and evidence blocks;
- overview, detail, and evidence disclosure;
- print CV;
- content compilation and validation;
- GitHub Pages deployment.

The prototype does not contain repository collection, LLM calls, authentication, a database, realtime metrics, job-ad tailoring, terminal emulation, carrier upload, complex graphs, or a general authoring UI.

## Vertical slice order

1. establish routes and GitHub Pages fallback;
2. add approved representative content under `src/content/`;
3. compile it to validated runtime JSON;
4. load it through one portfolio data service;
5. render homepage, CV, portfolio index, project detail, and print CV;
6. implement `ProseBlock`, `CodeBlock`, `CommentaryBlock`, `LinksBlock`, and `EvidenceBlock`;
7. add terminal, image, quote, callout, and related-content blocks only as the selected pages require them;
8. validate mobile, desktop, keyboard, direct refresh, unknown slug, and print;
9. deploy and compare public output with approved source.

## Representative content

Use approved content covering:

- Ulf's introduction and current direction;
- KTH work experience;
- Stockholm University Mathematical-Computer Science studies;
- selected competence areas;
- two projects with purpose, personal contribution, evidence, learning, and limitations;
- code or terminal examples retained as selectable text.

No placeholder claim may survive the public prototype. Unapproved wording remains outside runtime output.

## Prototype success

A visitor can understand Ulf and his work quickly, inspect richer project context, follow meaningful links, and print a coherent CV. A developer can add another conventional project through content and existing blocks without introducing a project-specific page component.

## Exit evidence

Capture named results for build, tests, content validation, routes, direct refresh, unknown slug, keyboard navigation, accessible names, responsive layouts, print review, links, deployed output, and semantic comparison with approved content.
