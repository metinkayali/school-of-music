import { AbsPitch, Pitch, PitchClass } from "./types";

export function pitch(ap: AbsPitch): Pitch {
  const n = ap % 12;
  const octave = Math.floor(ap/12);
  const layout: PitchClass[] = ['C', 'Cs', 'D', 'Ds', 'E', 'F', 'Fs', 'G', 'Gs', 'A', 'As', 'B'];
  return {
    octave,
    pitchClass: layout[n],
  };
}

export default pitch;