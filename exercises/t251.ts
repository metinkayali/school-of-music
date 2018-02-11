import {
  par, note, seq
} from '../constructors/music';
import {
  wn, bn
} from '../constants';

const dMin = par(
  par(
    note(wn, { octave: 4, pitchClass: 'D' }),
    note(wn, { octave: 4, pitchClass: 'F' })),
  note(wn, { octave: 4, pitchClass: 'A' })
);
const gMaj = par(
  par(
    note(wn, { octave: 4, pitchClass: 'G' }),
    note(wn, { octave: 4, pitchClass: 'B' })),
  note(wn, { octave: 5, pitchClass: 'D' })
);
const cMaj = par(
  par(
    note(bn, { octave: 4, pitchClass: 'C' }),
    note(bn, { octave: 4, pitchClass: 'E' })),
  note(bn, { octave: 4, pitchClass: 'G' })
);

export const t251 =
  seq(
    seq(dMin,
        gMaj),
    cMaj
);