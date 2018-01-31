import * as m from "./music";

const concertA: m.Pitch = { octave: 4, pitchClass: 'C' };
const prim: m.Prim<m.Pitch> = { primitive: { dur: 1, pitch: concertA } };
const music: m.Music<m.Pitch> = prim;

console.log(music);