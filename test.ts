import { t251 } from './exercises/t251';
import * as beautify from 'json-beautify';
import { trans } from './absolute-pitch'

const shiftOctave = trans(12);
console.log(shiftOctave({ octave: 4, pitchClass: 'Af' }));