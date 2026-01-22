# Deedplanner bridge calculator

This project aims to create a Wurm Online bridge creator CLI tool for Deedplanner 3, with the goal of:
- Being able to generate bridges that are possible in-game,
- which have the least amount of support parts.

Below is the ruleset upon which the project is based.

## Rope bridge

- **Sag:** 3-12%
   - Default sag should be 3% (in order to avoid generating as many impossible bridges as possible).
   - Sag can make the bridge impossible if they collide with the ground.
- **Width:** 1 tile
- **Minimum length:** 1 tile
- **Pavement:** No
- **Customizing structure:** No
- **Material:** Rope
- **Parts:**
   - AbutmentL,
   - AbutmentR,
   - Crown,
   - DoubleAbutment
- **Generated structure:**
   - Length = 1 → [DoubleAbutment],
   - Length = 2 → [AbutmentL, AbutmentR],
   - Length > 2 → [AbutmentL, (Length - 2) × Crown, AbutmentR]

## Flat masonry bridge

- **Width:** 1-3 tile(s)
- **Minimum length:** 1 tile
- **Solid wall limitation:** 2 stories below bridge
- **Materials:**
   - Brick,
   - Marble,
   - Slate,
   - Roundedstone,
   - Pottery,
   - Sandstone,
   - Rendered
- **Pavement:** Yes, except for corner placement
- **Parts:**
   - AbutmentL,
   - AbutmentR,
   - BracingL,
   - BracingR,
   - Crown,
   - DoubleAbutment,
   - DoubleBracing,
   - Support
- **Customizing structure:** Yes, if longer than 5
- **Generated structure:**
   - Length = 1 → [DoubleAbutment],
   - Length = 2 → [AbutmentL, AbutmentR],
   - Length = 3 → [AbutmentL, DoubleBracing, AbutmentR],
   - Length = 4 → [AbutmentL, BracingL, BracingR, AbutmentR],
   - Length = 5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR],
   - Length > 5:
      - Bridges longer then 5 will require at least 1 support.
      - We can use the same segments as is shown above, and with Supports in-between them, they can make up bridges longer than 5 tile.
      - The generation should use as few segments as possible, therefore implementing the minimum amount of supports.
      - For Example a bridge that is 14 tiles long can be made the following way with the least amount of supports:
5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 2 → [AbutmentL, AbutmentR],
- **Customizing structure:** Yes
   - Placed support **must** have non-support bridge parts neighboring them on **both** sides
   - Editing the bridge structure can temporarily result in impossible bridges. Two approach to handle that in the rendering:
      - Re-render bridge the first time when a possible layout is made
      - Have an apply button that is disabled when the bridge is impossible and enabled when possible, and then after a click it re-renders the bridge.

## Arched masonry bridge

- **Arch:** 5 | 10 | 15 | 20
   - Default arch should be 20.
- **Width:** 1-3 tile(s)
- **Minimum length:** 2 tiles
- **Pavement:** Yes, except corner placement
- **Solid wall limitation:** 2 stories below bridge
- **Customizing structure:** No
- **Materials:**
   - Brick,
   - Marble,
   - Slate,
   - Roundedstone,
   - Pottery,
   - Sandstone,
   - Rendered
- **Parts:**
   - AbutmentL,
   - AbutmentR,
   - BracingL,
   - BracingR,
   - Crown,
   - DoubleAbutment,
   - DoubleBracing,
   - Support
- **Generated structure:**
   - Length = 2 → [AbutmentL, AbutmentR],
   - Length = 3 → [AbutmentL, DoubleBracing, AbutmentR],
   - Length = 4 → [AbutmentL, BracingL, BracingR, AbutmentR],
   - 4 < Length < 9 → [AbutmentL, BracingL, (Length - 4) × Crown, BracingR, AbutmentR],
   - Length > 9 → [DoubleAbutment, Support, AbutmentL, BracingL, (Length - 8) × Crown, BracingR, AbutmentR, Support, DoubleAbutment],

## Flat wood bridge

- **Material:** Wood
- **Minimum length:** 1 tile
- **Width:** 1-2 tile(s)
- **Solid wall limitation:** 2 stories below bridge
- **Pavement:** No
- **Customizing structure:** Yes, if longer than 5
   - Placed support **must** have non-support bridge parts neighboring them on **both** sides
   - Editing the bridge structure can temporarily result in impossible bridges. Two approach to handle that in the rendering:
      - Re-render bridge the first time when a possible layout is made
      - Have an apply button that is disabled when the bridge is impossible and enabled when possible, and then after a click it re-renders the bridge.
- **Parts:**
   - AbutmentL,
   - AbutmentR,
   - Crown,
   - Support
- **Generated structure:**
   - Length = 1 → [Crown],
   - Length = 2 → [AbutmentL, AbutmentR],
   - Length = 3 → [AbutmentL, Crown, AbutmentR],
   - Length = 4 → [AbutmentL, Crown, Crown, AbutmentR],
   - Length = 5 → [AbutmentL,  Crown, Crown, Crown, AbutmentR],
   - Length > 5:
      - Bridges longer then 5 will require at least 1 support.
      - We can use the same segments as is shown above, and with Supports in-between them, they can make up bridges longer than 5 tile.
      - The generation should use as few segments as possible, therefore implementing the minimum amount of supports.
      - For Example a bridge that is 14 tiles long can be made the following way with the least amount of supports:
5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 2 → [AbutmentL, AbutmentR],

## Arched wood bridge

- **Material:** Wood
- **Minimum length:** 2 tile
- **Width:** 1-2 tile(s)
- **Pavement:** No
- **Customizing structure:** No
- **Solid wall limitation:** 2 stories below bridge
- **Arch:** 5 | 10 | 15 | 20
   - Default arch should be 20.
- **Parts:**
   - AbutmentL,
   - AbutmentR,
   - Crown,
   - Support
- **Generated structure:**
   - Length = 1 → [Crown],
   - Length = 2 → [AbutmentL, AbutmentR],
   - Length = 3 → [AbutmentL, Crown, AbutmentR],
   - Length = 4 → [AbutmentL, Crown, Crown, AbutmentR],
   - Length = 5 → [AbutmentL,  Crown, Crown, Crown, AbutmentR],
   - Length > 5:
      - Bridges longer then 5 will require at least 1 support.
      - We can use the same segments as is shown above, and with Supports in-between them, they can make up bridges longer than 5 tile.
      - The generation should use as few segments as possible, therefore implementing the minimum amount of supports.
      - For Example a bridge that is 14 tiles long can be made the following way with the least amount of supports:
5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 5 → [AbutmentL,  BracingL, Crown, BracingR, AbutmentR] + 1 → [Support] + 2 → [AbutmentL, AbutmentR],

## General rules:

- Bridges have to be min. 1 higher than water level.
- The whole bridge has to have 10 slopes clearing under.
- Cannot have plants under it.
- Bridges can’t cross.
- Max. length is 38.
- The tile border’s touching the bridge have to be level.
- The maximum slope for any bridge part is 20.
- Bridges cannot be built over any tile that has a settlement token or any opening into a mine. These obstacles must be located 2 tiles away from any bridge component.

## Bridge types:

- Rope
- Flat wood
- Flat brick
- Flat marble
- Flat slate
- Flat roundedstone
- Flat pottery
- Flat sandstone
- Flat rendered
- Arched wood
- Arched brick
- Arched marble
- Arched slate
- Arched roundedstone
- Arched pottery
- Arched sandstone
- Arched rendered

