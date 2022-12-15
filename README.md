# Realistic Ragdoll
This is a simple implementation of a ragdoll in Unity. The script uses the Rigidbody component to apply realistic physics to the ragdoll and make it fall realistically. It also checks if the ragdoll has come to a rest and, if so, disables and destroys itself to avoid running unnecessary calculations and save resources.

## Usage
To use this script, attach it to the root game object of your ragdoll hierarchy. The script will automatically populate a list of Rigidbody components in the hierarchy and apply downward force to them to make the ragdoll fall realistically.

# License
This project is licensed under the MIT License - see the LICENSE file for details.
