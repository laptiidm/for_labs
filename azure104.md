# AZ-104 Identity & Governance Lab Story

# Company Scenario

## Company Name

**NovaCore Solutions**

A mid-sized IT outsourcing company.

---

# Company Background

NovaCore:

* develops web/mobile/cloud solutions
* has internal departments
* collaborates with external contractors
* is migrating infrastructure into Azure

The company wants:

* centralized identity management
* role-based access
* governance
* cost control
* secure collaboration
* scalable cloud structure

You are the new Azure Administrator.

Your task:
👉 build the foundational Azure governance and identity environment.

---

# IMPORTANT REAL-WORLD CONSTRAINT

## Budget limitation

NovaCore is still a growing company.

Therefore:

* avoid expensive resources
* use smallest SKUs
* delete unused resources
* use tags and budgets
* prefer identity/governance tasks over compute-heavy deployments

This perfectly matches your real situation.

---

# MAIN LEARNING GOALS

This lab should teach you:

| Domain           | Goal                            |
| ---------------- | ------------------------------- |
| Identity         | users/groups/licenses           |
| RBAC             | permissions/scopes              |
| Governance       | policy/locks/tags               |
| Cost             | budgets/advisor                 |
| Tenant structure | subscriptions/management groups |
| Security mindset | least privilege                 |
| Troubleshooting  | inheritance/conflicts           |

---

# COMPANY STRUCTURE

## Departments

| Department           | Purpose               |
| -------------------- | --------------------- |
| IT                   | administrators/devops |
| Development          | developers            |
| Finance              | accounting/budget     |
| HR                   | employee management   |
| External Contractors | temporary guests      |

---

# USERS TO CREATE

## Admins

| User        | Role                 |
| ----------- | -------------------- |
| alice.admin | Global administrator |
| david.cloud | Azure administrator  |

---

## Employees

| User           | Department  |
| -------------- | ----------- |
| bob.dev        | Development |
| emma.dev       | Development |
| olivia.finance | Finance     |
| sophia.hr      | HR          |

---

## External Users

| User             | Type  |
| ---------------- | ----- |
| contractor.james | Guest |
| support.vendor   | Guest |

---

# GROUPS TO CREATE

| Group                  | Type     |
| ---------------------- | -------- |
| Dev-Team               | Security |
| Finance-Team           | Security |
| HR-Team                | Security |
| Cloud-Admins           | Security |
| External-Collaborators | Security |
| Dynamic-IT             | Dynamic  |

---

# TENANT STRUCTURE

You will simulate enterprise hierarchy.

---

# MANAGEMENT GROUP STRUCTURE

```text id="mg1"
NovaCore
 ├── Production
 └── Development
```

---

# RESOURCE GROUP STRUCTURE

## Development Environment

```text id="rg1"
rg-dev-identity
rg-dev-apps
rg-dev-storage
```

---

## Production Environment

```text id="rg2"
rg-prod-finance
rg-prod-shared
```

---

# IMPORTANT COST OPTIMIZATION

## DO NOT deploy:

* large VMs
* Kubernetes
* premium databases
* expensive networking

---

# SAFE RESOURCES FOR LABS

## Prefer:

| Resource          | Cost                   |
| ----------------- | ---------------------- |
| Resource Groups   | free                   |
| RBAC              | free                   |
| Policies          | free                   |
| Tags              | free                   |
| Locks             | free                   |
| Management Groups | free                   |
| Storage Account   | very cheap             |
| Small B1s VM      | acceptable temporarily |

---

# LAB PHASES

# PHASE 1 — Identity Foundation

## Tasks

### Create users

* configure departments
* configure usage location

### Create groups

* assigned groups
* dynamic groups

### Invite guest users

* validate external identities

---

# IMPORTANT DETAILS

## Learn:

* member vs guest
* assigned vs dynamic groups
* identity lifecycle

---

# PHASE 2 — Access Management (RBAC)

## Tasks

Assign:

* Reader
* Contributor
* Owner

At different scopes:

* subscription
* resource group
* resource

---

# IMPORTANT DETAILS

## Observe:

* inheritance
* deny by policy vs RBAC
* least privilege

---

# PHASE 3 — Governance

## Create policies

Examples:

* only East US region
* mandatory tags
* deny public IPs

---

# IMPORTANT DETAILS

## Learn:

* policy inheritance
* compliance state
* audit vs deny

---

# PHASE 4 — Protection

## Configure:

* resource locks
* delete protection

---

# IMPORTANT DETAILS

## Learn:

* CanNotDelete
* ReadOnly
* lock inheritance

---

# PHASE 5 — Cost Management

## Configure:

* budgets
* alerts

---

# IMPORTANT DETAILS

## Learn:

* forecast spending
* Azure Advisor recommendations

---

# PHASE 6 — Automation

## Azure CLI tasks

Examples:

```bash id="cli1"
az group create
az role assignment create
```

---

## PowerShell tasks

Examples:

```powershell id="ps1"
New-AzRoleAssignment
Get-AzADUser
```

---

# PHASE 7 — Troubleshooting Challenges

You intentionally create:

* wrong RBAC scope
* conflicting policy
* lock issue

Then debug:

* why access fails
* why deployment denied
* why deletion blocked

THIS is extremely valuable for AZ-104.

---

# MOST IMPORTANT CONCEPTS TO MASTER

| Concept          | Why Important          |
| ---------------- | ---------------------- |
| Tenant           | identity boundary      |
| Subscription     | billing boundary       |
| Management Group | governance inheritance |
| RBAC Scope       | permission propagation |
| Policy Scope     | compliance inheritance |
| Group Membership | access aggregation     |

---

# VERY IMPORTANT REAL-WORLD THINKING

You should constantly ask:

## “Why did the company choose this scope?”

Example:

* Why Reader instead of Contributor?
* Why resource-group scope instead of subscription?
* Why dynamic group?

This develops administrator reasoning.

---

# COST-SAFE STRATEGY

## Best practice for your lab

### Create resources

→ test them
→ document findings
→ DELETE afterwards

Especially:

* VMs
* public IPs
* disks

---

# FINAL GOAL

By the end of this lab, you should be able to:

✅ explain Azure identity architecture
✅ understand RBAC inheritance deeply
✅ troubleshoot access issues
✅ design governance structure
✅ think like Azure administrator
✅ answer scenario-based AZ-104 questions confidently

---

# Optional Next Step

After you approve this skeleton, we can build:

## “Phase 1 Detailed Task Sheet”

with:

* exact Azure actions
* CLI commands
* PowerShell commands
* expected results
* troubleshooting checkpoints
* exam insights
* architecture reasoning

That would become your actual hands-on workbook.
